﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using FluentAssertions;

using Microsoft.CodeAnalysis.Sarif.Converters;

using Xunit;

namespace Microsoft.CodeAnalysis.Sarif
{
    public class ExtensionsTests
    {
        [Fact]
        public void Extensions_PropertValue_NullProperties()
        {
            Dictionary<string, string> uut = null;
            Assert.Null(uut.PropertyValue("anything"));
        }

        [Fact]
        public void Extensions_PropertValue_UnsetValue()
        {
            var uut = new Dictionary<string, string>();
            Assert.Null(uut.PropertyValue("anything"));
        }

        [Fact]
        public void Extensions_PropertValue_SetValue()
        {
            var uut = new Dictionary<string, string>
            {
                { "anything", "the value" }
            };

            Assert.Equal("the value", uut.PropertyValue("anything"));
        }

        [Fact]
        public void Extensions_IsNewline_CarriageReturn()
        {
            '\r'.IsNewline().Should().BeTrue();
        }

        [Fact]
        public void Extensions_IsNewline_LineFeed()
        {
            '\n'.IsNewline().Should().BeTrue();
        }

        [Fact]
        public void Extensions_IsNewline_UnicodeLine()
        {
            '\u2028'.IsNewline().Should().BeTrue();
        }

        [Fact]
        public void Extensions_IsNewline_UnicodeParagraph()
        {
            '\u2029'.IsNewline().Should().BeTrue();
        }

        [Fact]
        public void Extensions_IsNewline_Other()
        {
            'E'.IsNewline().Should().BeFalse();
        }

        private static readonly char[] s_testArray = "  match   ".ToCharArray();
        // 0123456789

        [Fact]
        public void Extensions_ArrayMatches_NegativeStartIndex()
        {
            s_testArray.Matches(-1, "match").Should().BeFalse();
        }

        [Fact]
        public void Extensions_ArrayMatches_TooLong()
        {
            s_testArray.Matches(6, "match").Should().BeFalse();
        }

        [Fact]
        public void Extensions_ArrayMatches_Match()
        {
            s_testArray.Matches(2, "match").Should().BeTrue();
        }

        [Fact]
        public void Extensions_ArrayMatches_Mismatch()
        {
            s_testArray.Matches(0, "match").Should().BeFalse();
        }

        [Fact]
        public void Extensions_XmlCreateException_WithLineInfo()
        {
            // 0000000001111111111222222
            // 1234567890123456789012345
            using (XmlReader unitUnderTest = Utilities.CreateXmlReaderFromString("<hello> <world/> </hello>"))
            {
                unitUnderTest.Read(); // <hello>
                unitUnderTest.Read(); // <world>
                XmlException result = unitUnderTest.CreateException("cute fluffy kittens");
                Assert.Equal(1, result.LineNumber);
                Assert.Equal(8, result.LinePosition);
            }
        }

        [Fact]
        public void Extensions_XmlCreateException_WithoutLineInfo()
        {
            var testData = new XElement("hello", new XElement("world"));
            using (XmlReader unitUnderTest = testData.CreateReader())
            {
                unitUnderTest.Read(); // <hello>
                unitUnderTest.Read(); // <world />
                XmlException result = unitUnderTest.CreateException("hungry EVIL zombies");
                Assert.Equal(0, result.LineNumber);
                Assert.Equal(0, result.LinePosition);
            }
        }

        [Fact]
        public void Extensions_XmlCreateException_WithFormat()
        {
            var testData = new XElement("hello", new XElement("world"));
            using (XmlReader unitUnderTest = testData.CreateReader())
            {
                XmlException result = unitUnderTest.CreateException("hungry {0} zombies", "evil");
                Assert.Equal("hungry evil zombies", result.Message);
            }
        }

        private const string simpleXmlDoc = "<xml><skip_this>expected child content</skip_this><following/></xml>";

        [Fact]
        public void Extensions_XmlIgnoreElementContent_Required_Success()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.ReadStartElement("xml");
                xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Required);
                Assert.Equal("following", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Required_Failure_BadName()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.Read(); // <xml>
                Assert.Throws<XmlException>(() =>
                    xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Required)
                );
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Required_Failure_BadNodeType()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.Read(); // Position on <xml>
                xml.Read(); // Position on <skip_this>
                xml.Read(); // Position on simple content
                xml.Read(); // Position on </skip_this>
                Assert.Throws<XmlException>(() =>
                    xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Required)
                );
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Optional_Success()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.ReadStartElement("xml");
                xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Optional);
                Assert.Equal("following", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Optional_Failure_BadName()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.Read(); // Position on <xml>
                xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Optional);
                Assert.Equal("xml", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Optional_Failure_BadNodeType()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.Read(); // Position on <xml>
                xml.Read(); // Position on <skip_this>
                xml.Read(); // Position on simple content
                xml.Read(); // Position on </skip_this>
                xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Optional);
                xml.Read();
                Assert.Equal("following", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_OptionalMulti_Failure_BadNodeType()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.Read(); // Position on <xml>
                xml.Read(); // Position on <skip_this>
                xml.Read(); // Position on simple content
                xml.Read(); // Position on </skip_this>
                xml.IgnoreElement(xml.NameTable.Add("skip_this"), IgnoreOptions.Optional | IgnoreOptions.Multiple);
                xml.Read();
                Assert.Equal("following", xml.LocalName);
            }
        }

        private const string simpleXmlMulitDoc = "<xml><xml>child <unused /> content</xml><xml>following</xml></xml>";

        [Fact]
        public void Extensions_XmlIgnoreElement_Singular_DoesNotOverread()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlMulitDoc))
            {
                xml.Read(); // Position on <xml> at depth 0
                xml.Read(); // Position on <xml> at depth 1
                xml.IgnoreElement(xml.NameTable.Add("xml"), IgnoreOptions.Optional);
                Assert.Equal(XmlNodeType.Element, xml.NodeType);
                Assert.Equal("following", xml.ReadElementContentAsString());
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Multiple_DoesNotOverread()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlMulitDoc))
            {
                xml.Read(); // Position on <xml> at depth 0
                xml.Read(); // Position on <xml> at depth 1
                xml.IgnoreElement(xml.NameTable.Add("xml"), IgnoreOptions.Multiple);
                Assert.Equal(XmlNodeType.EndElement, xml.NodeType);
                Assert.Equal(0, xml.Depth);
            }
        }

        [Fact]
        public void Extensions_XmlIgnoreElement_Multiple_WhenRequiredReadsZeroElements()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlMulitDoc))
            {
                xml.Read(); // Position on <xml> at depth 0
                xml.Read(); // Position on <xml> at depth 1
                try
                {
                    xml.IgnoreElement(xml.NameTable.Add("different_element"), IgnoreOptions.Multiple);
                    Assert.True(false);
                }
                catch (XmlException) { }
                Assert.Equal(XmlNodeType.Element, xml.NodeType);
                Assert.Equal("xml", xml.LocalName);
                Assert.Equal(1, xml.Depth);
            }
        }

        [Fact]
        public void Extensions_XmlReadOptionalElementContentAsString_Success()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.ReadStartElement("xml");
                string elementName = xml.NameTable.Add("skip_this");
                Assert.Equal("expected child content", xml.ReadOptionalElementContentAsString(elementName));
            }
        }

        [Fact]
        public void Extensions_XmlReadOptionalElementContentAsString_Failure_BadNodeType()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.ReadStartElement("xml");
                xml.ReadStartElement("skip_this"); // Position in the simple content inside <skip_this/>
                xml.Read(); // Now on end element
                Assert.Equal(XmlNodeType.EndElement, xml.NodeType);
                string elementName = xml.NameTable.Add("skip_this");
                Assert.Null(xml.ReadOptionalElementContentAsString(elementName));
            }
        }

        [Fact]
        public void Extensions_XmlReadOptionalElementContentAsString_Failure_BadName()
        {
            using (XmlReader xml = Utilities.CreateXmlReaderFromString(simpleXmlDoc))
            {
                xml.ReadStartElement("xml");
                string elementName = xml.NameTable.Add("bad_name");
                Assert.Null(xml.ReadOptionalElementContentAsString(elementName));
            }
        }

        private static readonly XElement s_consumeElementOfDepthTestDocument =
            new XElement("root",
                new XElement("empty_child"),
                new XElement("content_child", "content"),
                new XElement("nodes_child", new XElement("node", "node content")),
                new XElement("deep_child", new XElement("node", new XElement("node")))
                );

        [Fact]
        public void Extensions_ConsumeElementOfDepth_AtLesserDepthTakesNoAction()
        {
            using (XmlReader xml = s_consumeElementOfDepthTestDocument.CreateReader())
            {
                xml.ConsumeElementOfDepth(1); // Already at endElementDepth 0, should have no effect
                Assert.Equal(ReadState.Initial, xml.ReadState);
            }
        }

        [Fact]
        public void Extensions_ConsumeElementOfDepth_ConsumesEmptyElement()
        {
            using (XmlReader xml = s_consumeElementOfDepthTestDocument.CreateReader())
            {
                Assert.True(xml.ReadToDescendant("empty_child"));
                Assert.True(xml.IsEmptyElement);
                xml.ConsumeElementOfDepth(1);
                Assert.Equal("content_child", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_ConsumeElementOfDepth_ConsumesElementWithChildren()
        {
            using (XmlReader xml = s_consumeElementOfDepthTestDocument.CreateReader())
            {
                Assert.True(xml.ReadToDescendant("nodes_child"));
                xml.ConsumeElementOfDepth(1);
                Assert.Equal(XmlNodeType.Element, xml.NodeType);
                Assert.Equal("deep_child", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_ConsumeElementOfDepth_ConsumesWhenAlreadyInsideElement()
        {
            using (XmlReader xml = s_consumeElementOfDepthTestDocument.CreateReader())
            {
                Assert.True(xml.ReadToDescendant("nodes_child"));
                Assert.True(xml.ReadToDescendant("node"));
                xml.Read();
                Assert.Equal(XmlNodeType.Text, xml.NodeType); // node content
                xml.ConsumeElementOfDepth(1);
                Assert.Equal(XmlNodeType.Element, xml.NodeType);
                Assert.Equal("deep_child", xml.LocalName);
            }
        }

        [Fact]
        public void Extensions_ConsumeElementOfDepth_ConsumesEndElement()
        {
            using (XmlReader xml = s_consumeElementOfDepthTestDocument.CreateReader())
            {
                Assert.True(xml.ReadToDescendant("nodes_child"));
                Assert.True(xml.ReadToDescendant("node"));
                Assert.True(xml.Read()); // node content
                Assert.True(xml.Read()); // </node> -- This test is that we consume the end element when we're standing on it
                Assert.Equal(XmlNodeType.EndElement, xml.NodeType);
                xml.ConsumeElementOfDepth(2);
                Assert.Equal(XmlNodeType.Element, xml.NodeType);
                Assert.Equal("deep_child", xml.LocalName);
            }
        }

        [Theory]
        [InlineData("first (example.dll) sentence. uncapitalized text", "first (example.dll) sentence. uncapitalized text.")]
        [InlineData("first 'example.dll' sentence. uncapitalized text", "first 'example.dll' sentence. uncapitalized text.")]
        [InlineData("first (') sentence. uncapitalized text", "first (') sentence. uncapitalized text.")]
        [InlineData("first '(' sentence. uncapitalized text", "first '(' sentence. uncapitalized text.")]
        [InlineData("first (example.dll) sentence. More text", "first (example.dll) sentence.")]
        [InlineData("first 'example.dll' sentence. More text", "first 'example.dll' sentence.")]
        [InlineData("first (') sentence. More text", "first (') sentence.")]
        [InlineData("first '(' sentence. More text", "first '(' sentence.")]
        [InlineData("We extract initial lines.\n more text", "We extract initial lines.")]
        [InlineData("We extract initial lines.\r more text", "We extract initial lines.")]
        [InlineData("We append periods", "We append periods.")]
        [InlineData("We append periods\nYes we do", "We append periods.")]
        [InlineData("Embedded periods, e.g., .config, does not fool us. Good return.", "Embedded periods, e.g., .config, does not fool us.")]
        [InlineData("Mismatched 'apostrophes', such as in a contraction, don't fool us anymore", "Mismatched 'apostrophes', such as in a contraction, don't fool us anymore.")]
        [InlineData("Misuse of exempli gratis, e.g. as here, no longer fools us.", "Misuse of exempli gratis, e.g. as here, no longer fools us.")]
        [InlineData("Abbreviations such as approx. don't fool us.", "Abbreviations such as approx. don't fool us.")]
        // Expected bad output cases
        [InlineData("no space after period.cannot return good sentence.", "no space after period.cannot return good sentence.")]
        [InlineData("In every result, at least one of the properties result.ruleId and result.rule.id must be present. If both are present, they must be equal.", "In every result, at least one of the properties result.ruleId and result.rule.id must be present.")]
        public void Extensions_ExtractsFirstSentenceProperly(string input, string expected)
        {
            string actual = ExtensionMethods.GetFirstSentence(input);
            actual.Should().Be(expected);
        }

        [Fact]
        public void Extensions_GetFileName()
        {
            const string expectedResult = "file.ext";
            var testCases = new List<(string, string)>
            {
                (null, null),
                (@"", string.Empty),
                (@"file.ext", expectedResult),
                (@"C:\path\file.ext", expectedResult),
                (@"\\hostname\path\file.ext", expectedResult),
                (@"file:///C:/path/file.ext", expectedResult),
                (@"file.ext?some-query-string", expectedResult),
                (@"\\hostname\c:\path\file.ext", expectedResult),
                (@"/home/username/path/file.ext", expectedResult),
                (@"~\home\username\path\file.ext", expectedResult),
                (@"nfs://servername/folder/file.ext", expectedResult),
                (@"file://hostname/C:/path/file.ext", expectedResult),
                (@"file:///home/username/path/file.ext", expectedResult),
                (@"ftp://ftp.example.com/folder/file.ext", expectedResult),
                (@"smb://servername/Share/folder/file.ext", expectedResult),
                (@"dav://example.hostname.com/folder/file.ext", expectedResult),
                (@"file://hostname/home/username/path/file.ext", expectedResult),
                (@"ftp://username@ftp.example.com/folder/file.ext", expectedResult),
                (@"scheme://servername.example.com/folder/file.ext", expectedResult),
                (@"https://github.com/microsoft/sarif-sdk/file.ext", expectedResult),
                (@"ssh://username@servername.example.com/folder/file.ext", expectedResult),
                (@"scheme://username@servername.example.com/folder/file.ext", expectedResult),
                (@"https://github.com/microsoft/sarif-sdk/file.ext?some-query-string", expectedResult),
            };

            var testCasesWithSlashReplaceable = new List<(string, string)>
            {
                (@"\", string.Empty),
                (@".\", string.Empty),
                (@"..\", string.Empty),
                (@"path\", string.Empty),
                (@"\path\", string.Empty),
                (@".\path\", string.Empty),
                (@"..\path\", string.Empty),
                (@"\file.ext", expectedResult),
                (@".\file.ext", expectedResult),
                (@"..\file.ext", expectedResult),
                (@"path\file.ext", expectedResult),
                (@"\path\file.ext", expectedResult),
                (@"..\path\file.ext", expectedResult),
                (@".\..\path\file.ext", expectedResult),
                (@"\file.ext?some-query-string", expectedResult),
                (@"path\file.ext?some-query-string", expectedResult),
                (@"\path\file.ext?some-query-string", expectedResult),
            };

            testCases.AddRange(testCasesWithSlashReplaceable);
            testCases.AddRange(testCasesWithSlashReplaceable.Select(t => (t.Item1.Replace(@"\", @"/"), t.Item2)));

            var testCasesWithMixSlash = new List<(string, string)>
            {
                (@"C:/path\file.ext", expectedResult),
                (@"C:\path/file.ext", expectedResult),
                (@"\\hostname/path\file.ext", expectedResult),
                (@"file:///C:\path/file.ext", expectedResult),
                (@"\\hostname/c:\path\file.ext", expectedResult),
                (@"\home\username/path/file.ext", expectedResult),
                (@"~\home\username/path/file.ext", expectedResult),
                (@"nfs://servername/folder\file.ext", expectedResult),
                (@"https://github.com/microsoft/sarif-sdk\file.ext", expectedResult),
            };

            testCases.AddRange(testCasesWithMixSlash);

            var sb = new StringBuilder();

            foreach ((string, string) testCase in testCases)
            {
                Uri uri = testCase.Item1 != null ? new Uri(testCase.Item1, UriKind.RelativeOrAbsolute) : null;
                string expectedFileName = testCase.Item2;

                string actualFileName = uri.GetFileName();

                if (!Equals(actualFileName, expectedFileName))
                {
                    sb.AppendFormat("Incorrect file name returned for uri '{0}'. Expected '{1}' but saw '{2}'.", uri, expectedFileName, actualFileName).AppendLine();
                }
            }

            sb.Length.Should().Be(0, because: "all URI to file name conversions should succeed but the following cases failed." + Environment.NewLine + sb.ToString());
        }

        [Fact]
        public void Extensions_DistinctMergeTests()
        {
            object[][] intTestCases = new[]
            {
                // first list, second list, comparer, expected list
                new object[] { null, null, null, null },
                new object[] { new List<int> { 1, 2, 3 } , null, null, null },
                new object[] { new List<int> { 1, 2, 3 }, new List<int> { 3, 2, 1 }, null, null },
                new object[] { new List<int> { 1, 2, 3 }, new List<int> { 4, 3, 2 }, EqualityComparer<int>.Default, new List<int> { 1, 2, 3, 4 } },
            };

            object[][] stringTestCases = new[]
            {
                new object[] { new List<string> {}, new List<string> {}, StringComparer.Ordinal, new List<string> {} },
                new object[] { new List<string> { "a", "b", "c" }, new List<string> {}, StringComparer.Ordinal, new List<string> { "a", "b", "c" } },
                new object[] { new List<string> {}, new List<string> { "a", "b", "c" }, StringComparer.Ordinal, new List<string> { "a", "b", "c" } },
                new object[] { new List<string> { "A", "B", "C" }, new List<string> { "a", "b", "c" }, StringComparer.Ordinal, new List<string> { "a", "b", "c", "A", "B", "C" } },
                new object[] { new List<string> { "A", "B", "C" }, new List<string> { "a", "b", "c" }, StringComparer.OrdinalIgnoreCase, new List<string> { "A", "B", "C" } },
                new object[] { new List<string> { "a", "a", "a" }, new List<string> { "B", "B", "B" }, StringComparer.Ordinal, new List<string> { "a", "B" } },
            };

            object[][] classTestCases = new[]
            {
                new object[]
                {
                    new List<Message> { new Message { Text = "Test/001" }, new Message { Text = "Test/002" } },
                    new List<Message> { new Message { Text = "Test/001" }, new Message { Text = "Test/002", Markdown = "`Test/002`" } },
                    Message.ValueComparer,
                    new List<Message> { new Message { Text = "Test/001" }, new Message { Text = "Test/002" }, new Message { Text = "Test/002", Markdown = "`Test/002`" } },
                },
            };

            foreach (object[] test in intTestCases)
            {
                var first = test[0] as IEnumerable<int>;
                var second = test[1] as IEnumerable<int>;
                var comparer = test[2] as IEqualityComparer<int>;
                var expected = test[3] as IEnumerable<int>;

                this.VerifyDistinctMerge(first, second, comparer, expected);
            }

            foreach (object[] test in stringTestCases)
            {
                var first = test[0] as IEnumerable<string>;
                var second = test[1] as IEnumerable<string>;
                var comparer = test[2] as IEqualityComparer<string>;
                var expected = test[3] as IEnumerable<string>;

                this.VerifyDistinctMerge(first, second, comparer, expected);
            }

            foreach (object[] test in classTestCases)
            {
                var first = test[0] as IEnumerable<Message>;
                var second = test[1] as IEnumerable<Message>;
                var comparer = test[2] as IEqualityComparer<Message>;
                var expected = test[3] as IEnumerable<Message>;

                this.VerifyDistinctMerge(first, second, comparer, expected);
            }
        }

        private void VerifyDistinctMerge<T>(IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer, IEnumerable<T> expected)
        {
            if (expected == null)
            {
                Action action = () => first.DistinctMerge(second, comparer).ToList();
                action.Should().Throw<ArgumentNullException>();
                return;
            }

            IEnumerable<T> actual = first.DistinctMerge(second, comparer);

            var actualSet = new HashSet<T>(actual, comparer);
            var expectedSet = new HashSet<T>(expected, comparer);
            actualSet.SetEquals(expectedSet).Should().Be(true);
        }
    }
}

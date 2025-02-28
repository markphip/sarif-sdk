// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Conversion for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "1.1.5.0")]
    internal sealed class ConversionComparer : IComparer<Conversion>
    {
        internal static readonly ConversionComparer Instance = new ConversionComparer();

        public int Compare(Conversion left, Conversion right)
        {
            int compareResult = 0;

            // TryReferenceCompares is an autogenerated extension method
            // that will properly handle the case when 'left' is null.
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = ToolComparer.Instance.Compare(left.Tool, right.Tool);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = InvocationComparer.Instance.Compare(left.Invocation, right.Invocation);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.AnalysisToolLogFiles.ListCompares(right.AnalysisToolLogFiles, ArtifactLocationComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Properties.DictionaryCompares(right.Properties, SerializedPropertyInfoComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            return compareResult;
        }
    }
}
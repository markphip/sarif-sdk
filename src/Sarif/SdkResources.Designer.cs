﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.CodeAnalysis.Sarif {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SdkResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SdkResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.CodeAnalysis.Sarif.SdkResources", typeof(SdkResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; is not a valid value for the id property of an threadFlowLocation object. The value must be a positive integer or the string representation of a positive integer..
        /// </summary>
        public static string AnnotatedCodeLocationIdMustBePositive {
            get {
                return ResourceManager.GetString("AnnotatedCodeLocationIdMustBePositive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The non-generic GetProperty method only works for properties that are JSON strings. To retrieve a property with any other .NET type, call the generic method GetProperty&lt;T&gt;(string propertyName), where T is the .NET type of the object stored in the specified property..
        /// </summary>
        public static string CallGenericGetProperty {
            get {
                return ResourceManager.GetString("CallGenericGetProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot provide version control information because the current directory &apos;{0}&apos; is not under a Git repository root directory..
        /// </summary>
        public static string CannotProvideVersionControlDetails {
            get {
                return ResourceManager.GetString("CannotProvideVersionControlDetails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot write result: Tool not yet written..
        /// </summary>
        public static string CannotWriteResultToolMissing {
            get {
                return ResourceManager.GetString("CannotWriteResultToolMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to --insert Hashes.
        /// </summary>
        public static string ComputeFileHashes_ReplaceInsertHashes {
            get {
                return ResourceManager.GetString("ComputeFileHashes_ReplaceInsertHashes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SARIF_{0}_ADDITION.
        /// </summary>
        public static string EnvironmentVariable_Additive_Format {
            get {
                return ResourceManager.GetString("EnvironmentVariable_Additive_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}{1}: error {2}: {3}.
        /// </summary>
        public static string ERR1000_ParseError {
            get {
                return ResourceManager.GetString("ERR1000_ParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All rules were explicitly disabled so there is no work to do..
        /// </summary>
        public static string ERR997_AllRulesExplicitlyDisabled {
            get {
                return ResourceManager.GetString("ERR997_AllRulesExplicitlyDisabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not access a file specified on the command line: &apos;{0}&apos;..
        /// </summary>
        public static string ERR997_ExceptionAccessingFile {
            get {
                return ResourceManager.GetString("ERR997_ExceptionAccessingFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not create output file &apos;{0}&apos;..
        /// </summary>
        public static string ERR997_ExceptionCreatingLogFile {
            get {
                return ResourceManager.GetString("ERR997_ExceptionCreatingLogFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not instantiate skimmers from the following plugins: {0}..
        /// </summary>
        public static string ERR997_ExceptionInstantiatingSkimmers {
            get {
                return ResourceManager.GetString("ERR997_ExceptionInstantiatingSkimmers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not load analysis target &apos;{0}&apos;..
        /// </summary>
        public static string ERR997_ExceptionLoadingAnalysisTarget {
            get {
                return ResourceManager.GetString("ERR997_ExceptionLoadingAnalysisTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not load the plugin &apos;{0}&apos;..
        /// </summary>
        public static string ERR997_ExceptionLoadingPlugIn {
            get {
                return ResourceManager.GetString("ERR997_ExceptionLoadingPlugIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; is not a property of the Invocation object..
        /// </summary>
        public static string ERR997_InvalidInvocationPropertyName {
            get {
                return ResourceManager.GetString("ERR997_InvalidInvocationPropertyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A required file specified on the command line could not be found: &apos;{0}&apos;..
        /// </summary>
        public static string ERR997_MissingFile {
            get {
                return ResourceManager.GetString("ERR997_MissingFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Check &apos;{0}&apos; was disabled while analyzing &apos;{1}&apos; because the analysis was not configured with required policy ({2}). To resolve this, configure and provide a policy file on the {3} command-line using the --policy argument (recommended), or pass &apos;--config default&apos; to invoke built-in settings. Invoke the {3} &apos;exportConfig&apos; command to produce an initial configuration file that can be edited, if necessary, and passed back into the tool..
        /// </summary>
        public static string ERR997_MissingReportingConfiguration {
            get {
                return ResourceManager.GetString("ERR997_MissingReportingConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No plugins were configured or successfully located and so no rules were loaded..
        /// </summary>
        public static string ERR997_NoPluginsConfigured {
            get {
                return ResourceManager.GetString("ERR997_NoPluginsConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not instantiate any analysis rules..
        /// </summary>
        public static string ERR997_NoRulesLoaded {
            get {
                return ResourceManager.GetString("ERR997_NoRulesLoaded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No valid analysis targets were specified..
        /// </summary>
        public static string ERR997_NoValidAnalysisTargets {
            get {
                return ResourceManager.GetString("ERR997_NoValidAnalysisTargets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The output file &apos;{0}&apos; already exists. Use --force to overwrite..
        /// </summary>
        public static string ERR997_OutputFileAlreadyExists {
            get {
                return ResourceManager.GetString("ERR997_OutputFileAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception of type &apos;{0}&apos; was raised analyzing &apos;{1}&apos; for check &apos;{2}&apos; (which has been disabled). The exception may have resulted from a problem related to parsing the analysis target, and not specific to the rule, however..
        /// </summary>
        public static string ERR998_ExceptionInAnalyze {
            get {
                return ResourceManager.GetString("ERR998_ExceptionInAnalyze", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception was raised attempting to determine whether &apos;{0}&apos; is a valid analysis target for check &apos;{1}&apos; (which has been disabled). The exception may have resulted from a problem related to parsing the analysis target and not specific to the rule, however..
        /// </summary>
        public static string ERR998_ExceptionInCanAnalyze {
            get {
                return ResourceManager.GetString("ERR998_ExceptionInCanAnalyze", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An exception was raised initializing check &apos;{0}&apos; (which has been disabled)..
        /// </summary>
        public static string ERR998_ExceptionInInitialize {
            get {
                return ResourceManager.GetString("ERR998_ExceptionInInitialize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}.
        /// </summary>
        public static string ERR999_UnhandledEngineException {
            get {
                return ResourceManager.GetString("ERR999_UnhandledEngineException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property name &apos;{0}&apos; is unrecognized.
        ///Known property names: baselineState, correlationGuid, guid, hostedViewerUri, kind, level, message.text, occurrenceCount, rank, ruleId
        ///You can also refer to properties in the result&apos;s property bag with &apos;properties.&lt;propertyName&gt;&apos;, or to properties in the associated rule&apos;s property bag with &apos;properties.rule.&lt;propertyName&gt;&apos;..
        /// </summary>
        public static string ErrorInvalidQueryPropertyName {
            get {
                return ResourceManager.GetString("ErrorInvalidQueryPropertyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property name must start with one of: {0}.
        /// </summary>
        public static string ErrorInvalidQueryPropertyPrefix {
            get {
                return ResourceManager.GetString("ErrorInvalidQueryPropertyPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When using the static &apos;Default&apos; instance of GitHelper, you must pass the argument useCache: false to GetRepositoryRoot, which degrades performance. If the performance is not acceptable, create a separate GitHelper instance. You need not pass useCache: true because that is the default..
        /// </summary>
        public static string GitHelperDefaultInstanceDoesNotPermitCaching {
            get {
                return ResourceManager.GetString("GitHelperDefaultInstanceDoesNotPermitCaching", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Element expected to be located under a different parent element..
        /// </summary>
        public static string InvalidParentXml {
            get {
                return ResourceManager.GetString("InvalidParentXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more invalid states were detected during serialization. This indicates that logging methods were called in the wrong order: {0}.
        /// </summary>
        public static string InvalidState {
            get {
                return ResourceManager.GetString("InvalidState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Line number supplied was out of range [1, numberOfLinesInFile + 1).
        /// </summary>
        public static string LineNumberWasOutOfRange {
            get {
                return ResourceManager.GetString("LineNumberWasOutOfRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analysis completed successfully..
        /// </summary>
        public static string MSG_AnalysisCompletedSuccessfully {
            get {
                return ResourceManager.GetString("MSG_AnalysisCompletedSuccessfully", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analyzing....
        /// </summary>
        public static string MSG_Analyzing {
            get {
                return ResourceManager.GetString("MSG_Analyzing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more targets was skipped entirely as it was determined to be an invalid target for analysis. Pass --verbose on the command-line for more information..
        /// </summary>
        public static string MSG_OneOrMoreInvalidTargets {
            get {
                return ResourceManager.GetString("MSG_OneOrMoreInvalidTargets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more rules was disabled for an analysis target, as it was determined not to be applicable to it (this is a common condition). Pass --verbose on the command-line for more information..
        /// </summary>
        public static string MSG_OneOrMoreNotApplicable {
            get {
                return ResourceManager.GetString("MSG_OneOrMoreNotApplicable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analysis did not complete due to one or more unrecoverable execution conditions..
        /// </summary>
        public static string MSG_UnexpectedApplicationExit {
            get {
                return ResourceManager.GetString("MSG_UnexpectedApplicationExit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Analyzing &apos;{0}&apos;....
        /// </summary>
        public static string MSG001_AnalyzingTarget {
            get {
                return ResourceManager.GetString("MSG001_AnalyzingTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; was not evaluated for check &apos;{1}&apos; because the analysis is not relevant for the following reason: {2}..
        /// </summary>
        public static string NotApplicable_InvalidMetadata {
            get {
                return ResourceManager.GetString("NotApplicable_InvalidMetadata", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} &apos;{1}&apos;.
        /// </summary>
        public static string NotificationWithExceptionMessage {
            get {
                return ResourceManager.GetString("NotificationWithExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not identify the log being partitioned. Call VisitSarifLog and provide the log to partition. This class is designed to create log files on a per-run basis (i.e., all partioned logs will contain a single run only)..
        /// </summary>
        public static string PartioningVisitHappensAtSarifLogLevel {
            get {
                return ResourceManager.GetString("PartioningVisitHappensAtSarifLogLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; does not exist. Consider calling TryGetProperty instead..
        /// </summary>
        public static string PropertyDoesNotExist {
            get {
                return ResourceManager.GetString("PropertyDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property bag contains a property {0} with the value null. It cannot be converted to the value type {1}..
        /// </summary>
        public static string PropertyOfValueTypeCannotBeNull {
            get {
                return ResourceManager.GetString("PropertyOfValueTypeCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The rule id &apos;{0}&apos; specified by the result does not match the actual id of the rule &apos;{1}&apos;.
        /// </summary>
        public static string ResultRuleIdDoesNotMatchRule {
            get {
                return ResourceManager.GetString("ResultRuleIdDoesNotMatchRule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object cannot be serialized until results serialization is completed..
        /// </summary>
        public static string ResultsSerializationNotComplete {
            get {
                return ResourceManager.GetString("ResultsSerializationNotComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run has already been written. It cannot be written again..
        /// </summary>
        public static string RunAlreadyWritten {
            get {
                return ResourceManager.GetString("RunAlreadyWritten", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tool has already been written. It cannot be written again..
        /// </summary>
        public static string ToolAlreadyWritten {
            get {
                return ResourceManager.GetString("ToolAlreadyWritten", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected fatal runtime condition(s) observed: .
        /// </summary>
        public static string UnexpectedFatalRuntimeConditions {
            get {
                return ResourceManager.GetString("UnexpectedFatalRuntimeConditions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value cannot be negative..
        /// </summary>
        public static string ValueCannotBeNegative {
            get {
                return ResourceManager.GetString("ValueCannotBeNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be greater than or equal to 1..
        /// </summary>
        public static string ValueMustBeAtLeastOne {
            get {
                return ResourceManager.GetString("ValueMustBeAtLeastOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Option &apos;{0}&apos; is invalid for this command..
        /// </summary>
        public static string WRN997_InvalidOption {
            get {
                return ResourceManager.GetString("WRN997_InvalidOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; was not analyzed as it does not appear to be a valid file type for analysis..
        /// </summary>
        public static string WRN997_InvalidTarget {
            get {
                return ResourceManager.GetString("WRN997_InvalidTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Option &apos;{0}&apos; is obsolete..
        /// </summary>
        public static string WRN997_ObsoleteOption {
            get {
                return ResourceManager.GetString("WRN997_ObsoleteOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Option &apos;{0}&apos; is obsolete.  Use &apos;{1}&apos; instead..
        /// </summary>
        public static string WRN997_ObsoleteOptionWithReplacement {
            get {
                return ResourceManager.GetString("WRN997_ObsoleteOptionWithReplacement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule &apos;{0}&apos; was disabled as it cannot run on the current platform &apos;{1}&apos;.  It can only run on &apos;{2}&apos;..
        /// </summary>
        public static string WRN998_NotSupportedPlatform {
            get {
                return ResourceManager.GetString("WRN998_NotSupportedPlatform", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rule &apos;{0}&apos; was explicitly disabled by the user. As result, this tool run cannot be used for compliance or other auditing processes that require a comprehensive analysis..
        /// </summary>
        public static string WRN999_RuleExplicitlyDisabled {
            get {
                return ResourceManager.GetString("WRN999_RuleExplicitlyDisabled", resourceCulture);
            }
        }
    }
}

// -----------------------------------------------------------------------
// <copyright file="EX1001.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using StyleCop.CSharp.Nexcel.Helper;

namespace StyleCop.CSharp.Nexcel.NexcelRules
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EX1003 : ElementRule
    {
        private const int MaximumLineCountWithoutDocument = 10;
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal EX1003()
            : base(
                RuleType.MethodMustBeDocumented,
                "EX1003",
                "",
                CustomRulesResources.DescriptionEX1003)
        {
        }

        public override void Analyze(SourceAnalyzer analyzer, CsElement element)
        {
            if (!element.Generated && element.ElementType == ElementType.Method)
            {
                var hasDocument = element.Header != null && !string.IsNullOrEmpty(element.Header.RawText);
                var lineCount = CodeHelper.GetElementSizeByDeclaration(element);
                if (lineCount > MaximumLineCountWithoutDocument && !hasDocument)
                {
                    analyzer.AddViolation(element, RuleName);
                }
            }
        }
    }
}

// -----------------------------------------------------------------------
// <copyright file="PlainTextRule.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace StyleCop.CSharp.Nexcel.NexcelRules
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class PlainTextRule : CustomRule
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal PlainTextRule(
            RuleType rule,
            string code,
            string settingName,
            string description)
            : base(rule, code, settingName, description)
        {
        }

        public abstract void Analyze(SourceAnalyzer analyzer, CsDocument document);
    }
}

// -----------------------------------------------------------------------
// <copyright file="ElementRule.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace StyleCop.CSharp.Nexcel.NexcelRules
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class ElementRule : CustomRule
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal ElementRule(
            RuleType rule,
            string code,
            string settingName,
            string description)
            : base(rule, code, settingName, description)
        {
        }

        public abstract void Analyze(SourceAnalyzer analyzer, CsElement element);
    }
}

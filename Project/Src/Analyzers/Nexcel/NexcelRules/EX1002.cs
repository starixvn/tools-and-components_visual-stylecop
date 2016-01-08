// -----------------------------------------------------------------------
// <copyright file="EX1001.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace StyleCop.CSharp.Nexcel.NexcelRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EX1002 : ElementRule
    {
         /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal EX1002()
            : base(
                RuleType.ClassMustBeDocumented,
                "EX1002",
                "",
                CustomRulesResources.DescriptionEX1002)
        {
        }

        public override void Analyze(SourceAnalyzer analyzer, CsElement element)
        {
            if (!element.Generated
               && element.ElementType == ElementType.Class
               &&
                (element.Header == null
                || (element.Header != null && string.IsNullOrEmpty(element.Header.RawText))
                )
                )
            {
                analyzer.AddViolation(element, RuleName);
            }
        }
    }
}

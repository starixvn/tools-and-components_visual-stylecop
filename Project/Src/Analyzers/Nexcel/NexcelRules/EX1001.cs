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
    public class EX1001 : ElementRule
    {
         /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal EX1001()
            : base(
                RuleType.PrivateFieldUnderscorePrefix,
                "EX1001",
                "",
                CustomRulesResources.DescriptionEX1001)
        {
        }

        public override void Analyze(SourceAnalyzer analyzer, CsElement element)
        {
            if (!element.Generated
               && element.ElementType == ElementType.Field
               && !element.Declaration.ContainsModifier(CsTokenType.Const)
               && !element.Declaration.ContainsModifier(CsTokenType.Static)
               && element.ActualAccess != AccessModifierType.Public
               && element.ActualAccess != AccessModifierType.Protected
               && element.ActualAccess != AccessModifierType.Internal
               && element.Declaration.Name.ToCharArray()[0] != '_')
            {
                analyzer.AddViolation(element, RuleName);
            }
        }
    }
}

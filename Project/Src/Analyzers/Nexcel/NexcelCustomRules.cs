// --------------------------------------------------------------------------
// <copyright file="NexcelRulesChecking.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Ricky.Nguyen" date="2013.7.4">Created</change>
// </history>


namespace StyleCop.CSharp.Nexcel
{
    using StyleCop.CSharp.Nexcel.NexcelRules;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class NexcelCustomRules : SourceAnalyzer
    {
        #region Rules

        private static Dictionary<RuleType, CustomRule> _rules;

        static NexcelCustomRules()
        {
            _rules = new Dictionary<RuleType, CustomRule>();

            Add(new SP2100());
            Add(new SP2101());
            Add(new SP2102());
            Add(new SP2103());
        }

        /// <summary>
        /// Adds specified rule to inner collection.
        /// </summary>
        private static void Add(CustomRule customRule)
        {
            _rules.Add(customRule.Rule, customRule);
        }

        #endregion

        #region Settings

        public void LoadSettings()
        {
            var rules = _rules;
            var ruleTypes = rules.Keys;
            foreach (var ruleType in ruleTypes)
            {
                var rule = rules[ruleType];
                if (!string.IsNullOrEmpty(rule.SettingName))
                {
                    var limit = GetValue<string>(rule.SettingName);
                    var limitValue = 0;

                    if (int.TryParse(limit, out limitValue))
                    {
                        rule.Limit = limitValue;
                    }
                }
            }
        }

        /// <summary>
        /// Gets property descriptor with existing check.
        /// </summary>
        private PropertyDescriptor GetDescriptor(string settingName)
        {
            var descriptor = PropertyDescriptors[settingName];
            if (descriptor == null)
                throw new InvalidDataException("Setting " + settingName + " is not registered as a known one.");

            return descriptor;
        }

        /// <summary>
        /// Gets property value for specified setting.
        /// </summary>
        public T GetValue<T>(string settingName)
        {
            var descriptor = (PropertyDescriptor<T>)GetDescriptor(settingName);
            return descriptor.DefaultValue;
        }

        #endregion

        #region Custom Rules

        /// <summary>
        /// Run throw document and check
        /// </summary>
        /// <param name="document">Document need to be checked</param>
        public override void AnalyzeDocument(CodeDocument document)
        {
            LoadSettings();

            var csdocument = (CsDocument)document;

            if (csdocument.RootElement != null
                && !csdocument.RootElement.Generated)
            {                
                foreach (var rule in _rules)
                {
                    if (rule.Value is PlainTextRule)
                    {
                        ((PlainTextRule)rule.Value).Analyze(this, csdocument);
                    }
                    else if (rule.Value is ElementRule)
                    {
                        csdocument.WalkDocument(new CodeWalkerElementVisitor<ElementRule>(this.VisitElement), (ElementRule)rule.Value);
                    }
                }
            }


        }

        /// <summary>
        /// Visit Element and add violation if violdate
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="parentElement">Parent Element</param>
        /// <param name="context">Context</param>
        /// <returns>True</returns>
        private bool VisitElement(CsElement element, CsElement parentElement, ElementRule context)
        {
            context.Analyze(this, element);

            return true;
        }

        #endregion
    }
}

using System;
using StyleCop.CSharp.Nexcel.Helper;
namespace StyleCop.CSharp.Nexcel.NexcelRules
{
	/// <summary>
	/// Represents a single custom rule.
	/// </summary>
	public abstract class CustomRule
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		internal CustomRule(
			RuleType rule,
			string code,
			string settingName,
			string description)
		{
			Rule = rule;
			Code = code;
			SettingName = settingName;
			Description = description;
            
		}

		#region Properties

		/// <summary>
		/// Gets rule object.
		/// </summary>
		internal RuleType Rule { get; private set; }

		/// <summary>
		/// Gets rule code.
		/// </summary>
		public string Code { get; private set; }

		/// <summary>
		/// Gets rule name.
		/// </summary>
		public string RuleName
		{
			get
			{
				return Rule.ToString();
			}
		}

		/// <summary>
		/// Gets rule setting name.
		/// </summary>
		public string SettingName { get; private set; }

		/// <summary>
		/// Gets rule description.
		/// </summary>
		public string Description { get; private set; }

        /// <summary>
        /// Gets or sets rule limit
        /// </summary>
        public int Limit { get; set; }

		#endregion

        #region Working with elements size

        /// <summary>
        /// Checks if specified element violates size limit.
        /// </summary>
        public bool CheckSizeLimit(SourceAnalyzer analyzer, CsElement element)
        {
            int size = CodeHelper.GetElementSizeByDeclaration(element);

            if (size > Limit)
            {
                analyzer.AddViolation(
                    element,
                    RuleName,
                    Limit,
                    size);
                
                return false;
            }

            return true;
        }

        #endregion
    }
}

namespace StyleCop.CSharp.Nexcel.NexcelRules
{
	/// <summary>
	/// Enumerates all rules used in add-in.
	/// </summary>
	internal enum RuleType
	{

		#region More custom rules

        /// <summary>
        /// Validates that private field mus be prefixed by underscore
        /// </summary>
        PrivateFieldUnderscorePrefix,

        /// <summary>
        /// Validates that class must have the document
        /// </summary>
        ClassMustBeDocumented,

        /// <summary>
        /// Validates that method must have the document
        /// </summary>
        MethodMustBeDocumented,

		/// <summary>
		/// Validates that code line is not longer than specified characters count.
		/// </summary>
		CodeLineMustNotBeLongerThan,

		/// <summary>
		/// Validates that method body does not contain more code lines than specified.
		/// </summary>
		MethodMustNotContainMoreLinesThan,

		/// <summary>
		/// Validates that property body does not contain more code lines than specified.
		/// </summary>
		PropertyMustNotContainMoreLinesThan,

		/// <summary>
		/// Validates that source file does not contain more code lines than specified.
		/// </summary>
		FileMustNotContainMoreLinesThan

		#endregion
	}
}

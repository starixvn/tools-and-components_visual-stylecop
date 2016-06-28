namespace StyleCop.CSharp.StylecopPlus
{
    /// <summary>
    /// SP2101 custom rule.
    /// </summary>
    public class SP2101 : ElementRule
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal SP2101()
            : base(
                RuleType.MethodMustNotContainMoreLinesThan,
                "SP2101",
                "SP2101_Limit",
                Resources.DescriptionSP2101)
        {
            Limit = 50;
        }

        public override void Analyze(SourceAnalyzer analyzer, CsElement element)
        {
            switch (element.ElementType)
            {
                case ElementType.Constructor:
                case ElementType.Destructor:
                case ElementType.Method:
                    CheckSizeLimit(analyzer, element);
                    break;
                default:
                    break;
            }
        }
    }
}

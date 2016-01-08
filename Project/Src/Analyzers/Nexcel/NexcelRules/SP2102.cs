namespace StyleCop.CSharp.Nexcel.NexcelRules
{
    /// <summary>
    /// SP2102 custom rule.
    /// </summary>
    public class SP2102 : ElementRule
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal SP2102()
            : base(
                RuleType.PropertyMustNotContainMoreLinesThan,
                "SP2102",
                "SP2102_Limit",
                CustomRulesResources.DescriptionSP2102)
        {
            Limit = 50;
        }

        public override void Analyze(SourceAnalyzer analyzer, CsElement element)
        {
            switch (element.ElementType)
            {
                case ElementType.Indexer:
                    AnalyzeIndexer(analyzer, element);
                    break;
                case ElementType.Property:
                    AnalyzeProperty(analyzer, element);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Analyzes indexer element.
        /// </summary>
        private void AnalyzeIndexer(SourceAnalyzer analyzer, CsElement element)
        {
            var indexer = (Indexer)element;

            if (indexer.GetAccessor != null)
            {
                CheckSizeLimit(
                  analyzer,
                  indexer.GetAccessor);
            }

            if (indexer.SetAccessor != null)
            {
                CheckSizeLimit(
                    analyzer,
                    indexer.SetAccessor);
            }
        }

        /// <summary>
        /// Analyzes property element.
        /// </summary>
        private void AnalyzeProperty(SourceAnalyzer analyzer, CsElement element)
        {
            var property = (Property)element;

            if (property.GetAccessor != null)
            {
                CheckSizeLimit(
                   analyzer,
                   property.GetAccessor);
            }

            if (property.SetAccessor != null)
            {
                CheckSizeLimit(
                   analyzer,
                   property.SetAccessor);
            }
        }
    }
}

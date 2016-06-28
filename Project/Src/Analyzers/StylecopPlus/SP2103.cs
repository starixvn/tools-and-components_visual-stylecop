namespace StyleCop.CSharp.StylecopPlus
{
    /// <summary>
    /// SP2103 custom rule.
    /// </summary>
    public class SP2103 : PlainTextRule
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal SP2103()
            : base(
                RuleType.FileMustNotContainMoreLinesThan,
                "SP2103",
                "SP2103_Limit",
                Resources.DescriptionSP2103)
        {
            Limit = 2000;
        }

        public override void Analyze(SourceAnalyzer analyzer, CsDocument document)
        {
            var lineCount = 0;
            using (var reader = document.SourceCode.Read())
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }

                reader.Close();
            }

            if (lineCount > Limit)
            {
                var element = document.RootElement;
                analyzer.AddViolation(
                    element,
                    RuleName,
                    Limit,
                    lineCount);
            }
        }
    }
}

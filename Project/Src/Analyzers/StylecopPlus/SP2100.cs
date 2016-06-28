using StyleCop.CSharp.StylecopPlus.Helper;
using System;
using System.Collections.Generic;

namespace StyleCop.CSharp.StylecopPlus
{
    /// <summary>
    /// SP2100 custom rule.
    /// </summary>
    public class SP2100 : PlainTextRule
    {
        private const int MaxCharacterInLine = 160;
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        internal SP2100()
            : base(
                RuleType.CodeLineMustNotBeLongerThan,
                "SP2100",
                "SP2100_Limit",
                Resources.DescriptionSP2100)
        {
            Limit = MaxCharacterInLine;
        }

        public override void Analyze(SourceAnalyzer analyzer, CsDocument document)
        {
            string source;
            using (var reader = document.SourceCode.Read())
            {
                source = reader.ReadToEnd();
                reader.Close();
            }

            var lines = new List<string>(
                source.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None));

            for (var i = 0; i < lines.Count; i++)
            {
                var currentLineNumber = i + 1;
                var currentLine = lines[i];
                CheckLineLength(analyzer, document, currentLine, currentLineNumber);
            }
        }

        /// <summary>
        /// Checks length of specified code line.
        /// </summary>
        private bool CheckLineLength(SourceAnalyzer analyzer,
            CsDocument document,
            string currentLine,
            int lineNumber)
        {
            currentLine = string.IsNullOrEmpty(currentLine)
                ? string.Empty
                : currentLine.Trim();

            var length = currentLine.Trim().Length;
            if (length > Limit)
            {
                var element = CodeHelper.GetElementByLine(document, lineNumber) ?? document.RootElement;
                analyzer.AddViolation(
                    element,
                    lineNumber,
                    RuleName,
                    Limit,
                    length);

                return false;
            }

            return true;
        }
    }
}

namespace NetQuick.Core.Utils
{
    public class FormattedStringBuilderSettings
    {
        public IdentationFormat IndentationType { get; set; }
        public NestingFormat NestingFormat { get; set; }
        public char IndentationCharacter { get; set; }
        public char UnindentationCharacter { get; set; }

        public static FormattedStringBuilderSettings Default
        {
            get
            {
                return new FormattedStringBuilderSettings
                {
                    IndentationCharacter = '{',
                    UnindentationCharacter = '}',
                    IndentationType = IdentationFormat.Spaces,
                    NestingFormat = NestingFormat.StartOnNewLine
                };
            }
        }       
    }

    public enum NestingFormat
    {
        StartOnNewLine,
        StartOnSameLine
    }
}
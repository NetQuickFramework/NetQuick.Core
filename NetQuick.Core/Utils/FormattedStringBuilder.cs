using System;
using System.Text;

namespace NetQuick.Core.Utils
{
    public class FormattedStringBuilder
    {
        private readonly StringBuilder _stringBuilder;
        private int _currentLevel;
        private bool _lastActionWasLine;
        private string _indentation;
        private FormattedStringBuilderSettings _settings;
        private int _lastAddedCharactersLenght = 0;

        public FormattedStringBuilder() : this(FormattedStringBuilderSettings.Default)
        {

        }

        public FormattedStringBuilder(FormattedStringBuilderSettings settings)
        {
            _stringBuilder = new StringBuilder();
            _currentLevel = 0;
            _settings = settings;
            _indentation = settings.IndentationType == IdentationFormat.Spaces ? "    " : "/t";
        }

        public void Unindent()
        {
            _currentLevel = Math.Max(0, _currentLevel - 1);
            AppendLine(_settings.UnindentationCharacter.ToString());
        }

        public void Indent()
        {
            if (_settings.NestingFormat == NestingFormat.StartOnSameLine)
            {
                if (_lastActionWasLine)
                {
                    _stringBuilder.Length -= _lastAddedCharactersLenght;
                }
                _stringBuilder.Append($" {_settings.IndentationCharacter}");
                AppendLine();               
            }
            if (_settings.NestingFormat == NestingFormat.StartOnNewLine)
                AppendLine(_settings.IndentationCharacter.ToString());

            _currentLevel++;           
        }

        public void AppendLine()
        {
            var currentLength = _stringBuilder.Length;            
            _stringBuilder.AppendLine();
            _lastAddedCharactersLenght = _stringBuilder.Length - currentLength;

            _lastActionWasLine = true;
        }

        public void Append(string value)
        {
            string correctedValue = _lastActionWasLine ? string.Concat(GetIndentation(), value) : value;

            _stringBuilder.Append(correctedValue);
            _lastActionWasLine = false;
        }

        public void AppendLine(string value)
        {
            _lastActionWasLine = true;
            _stringBuilder.AppendLine(string.Concat(GetIndentation(), value));
        }

        private string GetIndentation()
        {
            var indentedStringBuilder = new StringBuilder();
            for (int x = 0; x < _currentLevel; x++)
            {
                indentedStringBuilder.Append(_indentation);
            }

            return indentedStringBuilder.ToString();
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
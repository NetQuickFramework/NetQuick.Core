namespace NetQuick.Core.Validation
{
    public class MaxLengthValidator : IValidator
    {
        internal MaxLengthValidator(int maxLength)
        {
            MaxLength = maxLength;
        }

        public int MaxLength { get; }
    }
}

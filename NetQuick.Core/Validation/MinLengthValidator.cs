namespace NetQuick.Core.Validation
{

    public class MinLengthValidator : IValidator
    {
        internal MinLengthValidator(int minLenght)
        {
            MinLenght = minLenght;
        }

        public int MinLenght { get; }
    }
}

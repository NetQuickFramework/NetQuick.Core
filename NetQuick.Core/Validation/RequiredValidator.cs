namespace NetQuick.Core.Validation
{
    public class RequiredValidator : IValidator
    {
        internal RequiredValidator(bool required = true)
        {
            Required = required;
        }       

        public bool Required { get; }
    }    
}

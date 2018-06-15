using NetQuick.Core.Validation;

namespace NetQuick.Core
{
    public interface IPropertyBuilderValidationExtension : IPropertyBuilderExtension
    {
        void Attach();
    }

    public interface IPropertyBuilderValidationExtension<TValidator> : IPropertyBuilderValidationExtension where TValidator : IValidator
    {
      
    }
}
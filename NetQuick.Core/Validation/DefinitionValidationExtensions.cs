using NetQuick.Core.Definitions;

namespace NetQuick.Core.Validation
{
    public static class DefinitionValidationExtensions
    {
        public static PropertyDefinition MaxLenght(this PropertyDefinition propertyDefinition, int maxLenght)
        {
            propertyDefinition.Extensions.Add(new MaxLengthValidator(maxLenght));
            return propertyDefinition;
        }

        public static PropertyDefinition SetMinLenght(this PropertyDefinition propertyDefinition, int minLenght)
        {
            propertyDefinition.Extensions.Add(new MinLengthValidator(minLenght));
            return propertyDefinition;
        }

        public static PropertyDefinition IsRequired(this PropertyDefinition propertyDefinition, bool required = true)
        {
            propertyDefinition.Extensions.Add(new RequiredValidator(required));
            return propertyDefinition;
        }
    }
}

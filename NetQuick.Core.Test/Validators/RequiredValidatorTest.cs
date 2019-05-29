using NetQuick.Core.Definitions;
using NetQuick.Core.Validation;
using Xunit;

namespace NetQuick.Core.Test.Validators
{
    public class RequiredValidatorTest
    {
        [Fact]
        public void Validator_IsInitialized()
        {
            const bool required = true;
            var validator = new RequiredValidator(required);

            Assert.Equal(required, validator.Required);
        }

        [Fact]
        public void Validator_IsAddedToProperty()
        {
            const bool required = true;

            ModelDefinition modelDefinition = new ModelDefinition("myClass");
            PropertyDefinition propertyDefinition = new PropertyDefinition("myProperty", "", modelDefinition, Cardinality.OneToOne, false);
            propertyDefinition.IsRequired(required);

            Assert.Equal(1, propertyDefinition.Extensions.Count);
            Assert.IsAssignableFrom<RequiredValidator>(propertyDefinition.Extensions[0]);
            Assert.Equal(required, (propertyDefinition.Extensions[0] as RequiredValidator).Required);
        }
    }
}

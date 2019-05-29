using NetQuick.Core.Definitions;
using NetQuick.Core.Validation;
using Xunit;

namespace NetQuick.Core.Test.Validators
{
    public class MinLenghtValidatorTest
    {
        [Fact]
        public void Validator_IsInitialized()
        {
            const int minLength = 10;
            var validator = new MinLengthValidator(minLength);

            Assert.Equal(minLength, validator.MinLenght);
        }

        [Fact]
        public void Validator_IsAddedToProperty()
        {
            const int minLength = 10;

            PropertyDefinition propertyDefinition = new PropertyDefinition("myProperty", "", null, Cardinality.OneToOne, false);
            propertyDefinition.SetMinLenght(minLength);

            Assert.Equal(1, propertyDefinition.Extensions.Count);
            Assert.IsAssignableFrom<MinLengthValidator>(propertyDefinition.Extensions[0]);
            Assert.Equal(minLength, (propertyDefinition.Extensions[0] as MinLengthValidator).MinLenght);
        }
    }
}

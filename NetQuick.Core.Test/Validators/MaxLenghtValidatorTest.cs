using NetQuick.Core.Definitions;
using NetQuick.Core.Validation;
using Xunit;

namespace NetQuick.Core.Test.Validators
{
 
    public class MaxLenghtValidatorTest
    {
        [Fact]
        public void Validator_IsInitialized()
        {
            const int maxLenght = 255;
            var validator = new MaxLengthValidator(maxLenght);

            Assert.Equal(maxLenght, validator.MaxLength);
        }

        [Fact]
        public void Validator_IsAddedToProperty()
        {
            const int maxLenght = 255;

            PropertyDefinition propertyDefinition = new PropertyDefinition("myProperty", "", null, Cardinality.OneToOne, true);
            propertyDefinition.MaxLenght(maxLenght);

            Assert.Equal(1, propertyDefinition.Extensions.Count);
            Assert.IsAssignableFrom<MaxLengthValidator>(propertyDefinition.Extensions[0]);
            Assert.Equal(maxLenght, (propertyDefinition.Extensions[0] as MaxLengthValidator).MaxLength);            
        }
    }
}

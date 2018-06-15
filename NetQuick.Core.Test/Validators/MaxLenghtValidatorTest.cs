using NetQuick.Core.Definitions;
using NetQuick.Core.Validation;
using NUnit.Framework;

namespace NetQuick.Core.Test.Validators
{
    [TestFixture]
    class MaxLenghtValidatorTest
    {
        [Test]
        public void Validator_IsInitialized()
        {
            const int maxLenght = 255;
            var validator = new MaxLengthValidator(maxLenght);

            Assert.That(validator.MaxLength, Is.EqualTo(maxLenght));
        }

        [Test]
        public void Validator_IsAddedToProperty()
        {
            const int maxLenght = 255;

            PropertyDefinition propertyDefinition = new PropertyDefinition("myProperty", "", null, Cardinality.OneToOne);
            propertyDefinition.MaxLenght(maxLenght);

            Assert.That(propertyDefinition.Extensions.Count, Is.EqualTo(1));
            Assert.That(propertyDefinition.Extensions[0], Is.InstanceOf<MaxLengthValidator>());
            Assert.That((propertyDefinition.Extensions[0] as MaxLengthValidator).MaxLength, Is.EqualTo(maxLenght));
        }
    }
}

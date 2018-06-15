using NetQuick.Core.Definitions;
using NetQuick.Core.Validation;
using NUnit.Framework;

namespace NetQuick.Core.Test.Validators
{
    [TestFixture]
    class MinLenghtValidatorTest
    {
        [Test]
        public void Validator_IsInitialized()
        {
            const int minLength = 10;
            var validator = new MinLengthValidator(minLength);

            Assert.That(validator.MinLenght, Is.EqualTo(minLength));
        }

        [Test]
        public void Validator_IsAddedToProperty()
        {
            const int minLength = 10;

            PropertyDefinition propertyDefinition = new PropertyDefinition("myProperty", "", null, Cardinality.OneToOne);
            propertyDefinition.SetMinLenght(minLength);

            Assert.That(propertyDefinition.Extensions.Count, Is.EqualTo(1));
            Assert.That(propertyDefinition.Extensions[0], Is.InstanceOf<MinLengthValidator>());
            Assert.That((propertyDefinition.Extensions[0] as MinLengthValidator).MinLenght, Is.EqualTo(minLength));
        }
    }
}

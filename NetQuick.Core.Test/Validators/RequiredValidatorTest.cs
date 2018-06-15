using NetQuick.Core.Definitions;
using NetQuick.Core.Validation;
using NUnit.Framework;

namespace NetQuick.Core.Test.Validators
{
    [TestFixture]
    class RequiredValidatorTest
    {
        [Test]
        public void Validator_IsInitialized()
        {
            const bool required = true;
            var validator = new RequiredValidator(required);

            Assert.That(validator.Required, Is.EqualTo(required));
        }

        [Test]
        public void Validator_IsAddedToProperty()
        {
            const bool required = true;

            ModelDefinition modelDefinition = new ModelDefinition("myClass");
            PropertyDefinition propertyDefinition = new PropertyDefinition("myProperty", "", modelDefinition, Cardinality.OneToOne);
            propertyDefinition.IsRequired(required);

            Assert.That(propertyDefinition.Extensions.Count, Is.EqualTo(1));
            Assert.That(propertyDefinition.Extensions[0], Is.InstanceOf<RequiredValidator>());
            Assert.That((propertyDefinition.Extensions[0] as RequiredValidator).Required, Is.EqualTo(required));
        }
    }
}

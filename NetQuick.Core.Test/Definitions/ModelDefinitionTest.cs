using NetQuick.Core.Definitions;
using NUnit.Framework;
using System.Linq;
using NetQuick.Core.Validation;

namespace NetQuick.Core.Test
{
    [TestFixture]
    public class ModelDefinitionTest
    {
        [TestCase(DataType.Date)]
        [TestCase(DataType.Text)]
        [TestCase(DataType.Number)]
        public void CreateDataTypeDefinition(DataType dataType)
        {
            ModelDefinition definition = BuiltInModelDefinition.Create(dataType);

            Assert.That(definition.Name, Is.EqualTo(dataType.ToString()));
        }

        [Test]
        public void CreateModelDefinition()
        {
            //Arrange
            const string name = "Address";

            ModelDefinition addressDefinition = ModelDefinition.Create(name);

            addressDefinition.AddProperty("Street", BuiltInModelDefinition.Text);
            addressDefinition.AddProperty("HouseNumber", BuiltInModelDefinition.Number);
            addressDefinition.AddProperty("HouseNumberAddition", BuiltInModelDefinition.Text);
            addressDefinition.AddProperty("PostalCode", BuiltInModelDefinition.Text);
            addressDefinition.AddProperty("City", BuiltInModelDefinition.Text);
            
            Assert.That(addressDefinition.Name, Is.EqualTo(name));
            Assert.That(addressDefinition.PropertyDefinitions.Count(), Is.EqualTo(5));
        }

        [Test]
        public void CreateModelDefinition_2()
        {
            //Arrange
            const string name = "Person";

            ModelDefinition definition = ModelDefinition.Create(name);
            definition.AddProperty("FirstName", BuiltInModelDefinition.Text);
            definition.AddProperty("LastName", BuiltInModelDefinition.Text);
            definition.AddProperty("DateOfBirth", BuiltInModelDefinition.Date);
            definition.AddProperty("Gender", ListDataTypeDefinition.FromEnum<Gender>());
        } 
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}

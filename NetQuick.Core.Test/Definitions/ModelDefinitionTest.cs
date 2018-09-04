using NetQuick.Core.Definitions;
using NUnit.Framework;
using System.Linq;
using NetQuick.Core.Validation;
using System;

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
        public void CreateModelDefinitionWithNewlyDefinedProperties_Succeeds()
        {
            //Arrange
            const string personName = "Person";

            ModelDefinition personDefinition = ModelDefinition.Create(personName);
            personDefinition.AddProperty("FirstName", BuiltInModelDefinition.Text);
            personDefinition.AddProperty("LastName", BuiltInModelDefinition.Text);
            personDefinition.AddProperty("DateOfBirth", BuiltInModelDefinition.Date);
            personDefinition.AddProperty("Gender", ListDataTypeDefinition.FromEnum<Gender>());

            const string addressDefinitionName = "Address";

            ModelDefinition addressDefinition = ModelDefinition.Create(addressDefinitionName);

            addressDefinition.AddProperty("Street", BuiltInModelDefinition.Text);
            addressDefinition.AddProperty("HouseNumber", BuiltInModelDefinition.Number);
            addressDefinition.AddProperty("HouseNumberAddition", BuiltInModelDefinition.Text);
            addressDefinition.AddProperty("PostalCode", BuiltInModelDefinition.Text);
            addressDefinition.AddProperty("City", BuiltInModelDefinition.Text);

            personDefinition.AddProperty("Address", addressDefinition);

            Assert.That(personDefinition.Name, Is.EqualTo(personName));
            Assert.That(addressDefinition.PropertyDefinitions.Count(), Is.EqualTo(5));
            Assert.That(personDefinition.PropertyDefinitions
                .Single(p => p.Name == addressDefinitionName)
                .ModelDefinition.PropertyDefinitions.Count(), Is.EqualTo(5));
        }

        [Test]
        public void CreateModelDefinitionWithOnlyBuiltInProperties_Succeeds()
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
        public void CreateModelDefinitionWithoutName_ThrowsException()
        {
            //Arrange
            const string name = "";

            Assert.Throws<ArgumentException>(() => ModelDefinition.Create(name));            
        }       
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}

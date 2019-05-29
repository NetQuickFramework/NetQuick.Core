using NetQuick.Core.Definitions;
using System.Linq;
using System;
using Xunit;

namespace NetQuick.Core.Test
{
   
    public class ModelDefinitionTest
    {
        [Theory]
        [InlineData(DataType.Date)]
        [InlineData(DataType.Text)]
        [InlineData(DataType.Number)]
        public void CreateDataTypeDefinition(DataType dataType)
        {
            ModelDefinition definition = BuiltInModelDefinition.Create(dataType);

            Assert.Equal(definition.Name, dataType.ToString());
        }

        [Fact]
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

            Assert.Equal(personName, personDefinition.Name);
            Assert.Equal(5, addressDefinition.PropertyDefinitions.Count());
            Assert.Equal(5, personDefinition.PropertyDefinitions
                .Single(p => p.Name == addressDefinitionName)
                .ModelDefinition.PropertyDefinitions.Count());
        }

        [Fact]
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
            
            Assert.Equal(name, addressDefinition.Name);
            Assert.Equal(5, addressDefinition.PropertyDefinitions.Count());
        }       

        [Fact]
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

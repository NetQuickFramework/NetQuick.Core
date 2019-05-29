using NetQuick.Core.Definitions;
using Xunit;

namespace NetQuick.Core.Test.Definitions
{
   
    public class PropertyDefinitionTest
    {
        [Theory]
        [InlineData("MyFirstProperty", "My first property", Cardinality.OneToOne, true)]
        [InlineData("MyFirstProperty", "My first property", Cardinality.OneToMany, true)]
        [InlineData("MyFirstProperty", "My first property", Cardinality.OneToOne, false)]
        [InlineData("MyFirstProperty", "My first property", Cardinality.OneToMany, false)]
        public void PropertyDefinition_IsCreatedCorrectly(string name,  string description, Cardinality cardinality, bool required)
        {
            var modelDefinition = ModelDefinition.Create("MyFirstModel");           

            var propertyDefinition = PropertyDefinition.Create(name, description, modelDefinition, cardinality, required);

            Assert.Equal(name, propertyDefinition.Name);
            Assert.Equal(description, propertyDefinition.Description);
            Assert.Equal(cardinality, propertyDefinition.Cardinality);
            Assert.Equal(required, propertyDefinition.Required);
        }
    }
}

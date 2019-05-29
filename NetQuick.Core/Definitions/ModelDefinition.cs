using System;
using System.Collections.Generic;

namespace NetQuick.Core.Definitions
{

    public class ModelDefinition : IDefinition
    {
        public string Name { get; protected set; }
        public string Description { get; }
        public IList<IDefinitionExtension> Extensions { get; }

        public IEnumerable<PropertyDefinition> PropertyDefinitions { get { return _propertyDefinitions; } }       

        private IList<PropertyDefinition> _propertyDefinitions;

        internal ModelDefinition(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or having only whitespace characters.", nameof(name));
            }

            Name = name;
            _propertyDefinitions = new List<PropertyDefinition>();
            Extensions = new List<IDefinitionExtension>();
        }

        public static ModelDefinition Create(string name)
        {
            return new ModelDefinition(name);
        }      
              

        public PropertyDefinition AddProperty(string name, ModelDefinition modelDefinition, string description = "", Cardinality cardinality = Cardinality.OneToOne, bool isRequired = false)
        {
            var propertyDefinition = PropertyDefinition.Create(name, description, modelDefinition, cardinality, isRequired);
            _propertyDefinitions.Add(propertyDefinition);
            return propertyDefinition;
        }
    }
}


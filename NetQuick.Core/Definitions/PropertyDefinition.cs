using System;
using System.Collections.Generic;

namespace NetQuick.Core.Definitions
{
    /// <summary>
    /// Defines a property for a model.
    /// </summary>
    public class PropertyDefinition : IDefinition
    {
        internal PropertyDefinition(string name, string description, ModelDefinition modelDefinition, Cardinality cardinality, bool isRequired)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or having only whitespace characters.", nameof(name));
            }

            Name = name;
            Description = description;
            ModelDefinition = modelDefinition;
            Cardinality = cardinality;
            Required = isRequired;
            Extensions = new List<IDefinitionExtension>();           
        }        
      
        public string Name { get; set; }
        public ModelDefinition ModelDefinition { get; set; }
        public Cardinality Cardinality { get; set; }
        public string Description { get; }      
        public bool Required { get; private set; }

        public IList<IDefinitionExtension> Extensions { get; }

        internal static PropertyDefinition Create(string name, string description, ModelDefinition modelDefinition, Cardinality cardinality, bool isRequired)
        {
            return new PropertyDefinition(name, description, modelDefinition, cardinality, isRequired);
        }

        public override string ToString()
        {
            return $"{Name} ({ModelDefinition?.Name})";
        }
    }
}


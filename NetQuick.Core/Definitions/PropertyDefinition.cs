using NetQuick.Core.Validation;
using System;
using System.Collections.Generic;

namespace NetQuick.Core.Definitions
{
    /// <summary>
    /// Defines a property for a model.
    /// </summary>
    public class PropertyDefinition : IDefinition
    {
        internal PropertyDefinition(string name, string description, ModelDefinition modelDefinition, Cardinality cardinality)
        {
            Name = name;
            Description = description;
            ModelDefinition = modelDefinition;
            Cardinality = cardinality;
            Extensions = new List<IDefinitionExtension>();           
        }        
      
        public string Name { get; set; }
        public ModelDefinition ModelDefinition { get; set; }
        public Cardinality Cardinality { get; set; }
        public string Description { get; }      
        public bool Required { get; private set; }

        public IList<IDefinitionExtension> Extensions { get; }

        internal static PropertyDefinition Create(string name, string description, ModelDefinition modelDefinition, Cardinality cardinality)
        {
            return new PropertyDefinition(name, description, modelDefinition, cardinality);
        }      
    }
}


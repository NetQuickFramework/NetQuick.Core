using System;
using System.Collections.Generic;

namespace NetQuick.Core.Definitions
{
    public class ModelCollection
    {
        public string Name { get; }
        public IEnumerable<ModelDefinition> ModelDefinitions { get { return _modelDefinitions.Values; } }
        private IDictionary<string, ModelDefinition> _modelDefinitions;

        internal ModelCollection(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or having only whitespace characters.", nameof(name));
            }

            Name = name;
            _modelDefinitions = new Dictionary<string, ModelDefinition>();
        }

        public static ModelCollection Create(string name)
        {
            return new ModelCollection(name);
        }

        public ModelDefinition AddModel(string name)
        {
            if (_modelDefinitions.ContainsKey(name))
            {
                throw new Exception($"The collection already contains a item with name {name}.");
            }

            var modelDefinition = ModelDefinition.Create(name);
            _modelDefinitions.Add(name, modelDefinition);
            return modelDefinition;
        }
    }
}


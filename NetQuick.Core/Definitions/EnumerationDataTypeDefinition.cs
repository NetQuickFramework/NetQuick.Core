using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetQuick.Core.Definitions
{
    public class ListDataTypeDefinition : BuiltInModelDefinition
    {       
        public IReadOnlyDictionary<uint, string> Values { get; }

        internal ListDataTypeDefinition(string name, IDictionary<uint, string> values) : base(DataType.Enumeration)
        {
            Name = name;
            Values = new ReadOnlyDictionary<uint, string>(values);
        }

        public static ListDataTypeDefinition FromEnum<T>() 
        {
            if (!typeof(T).IsEnum)
            {
                throw new NotSupportedException($"the generic type parameter of type {typeof(T).Name} must be convertible to enum.");
            }

            var valueDictionary = new Dictionary<uint, string>();

            foreach(var item in Enum.GetValues(typeof(T)))
            {
                var id = Convert.ToUInt32(item);
               
                valueDictionary.Add(id, Enum.GetName(typeof(T), item));
            }

            return new ListDataTypeDefinition(typeof(T).Name, valueDictionary);
        }
    }
}


using System.Collections.Generic;

namespace NetQuick.Core.Builders
{
    public interface IPropertyBuilder : IBuilder
    {
        string PropertyName { get; }
        string PropertyType { get; }
        IEnumerable<IPropertyBuilderExtension> Extensions { get;  }       
    }
}
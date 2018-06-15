using System.Collections.Generic;

namespace NetQuick.Core
{
    public interface IClassBuilder : IBuilder
    {        
        string ClassName { get; }
        string DefaultFolder { get; }
        IList<IPropertyBuilder> PropertyBuilders { get; }  
        IList<IClassBuilderExtension> Extensions { get; }       
    }
}

using System.Collections.Generic;

namespace NetQuick.Core.Definitions
{
    public interface IDefinition
    {
        string Name { get; }
        string Description { get; }
        IList<IDefinitionExtension> Extensions { get; }
    }
}


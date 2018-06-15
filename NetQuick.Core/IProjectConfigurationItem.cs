using System.Collections.Generic;

namespace NetQuick.Core
{
    public interface IProjectConfigurationItem
    {
        IList<IProjectConfigurationExtension> Extensions { get; }
    }
}
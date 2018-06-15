using System.Collections.Generic;

namespace NetQuick.Core
{
    public class ProjectConfiguration
    {
        public IList<IProjectConfigurationItem> ChildConfigurationItems { get; }

        public ProjectConfiguration()
        {
            ChildConfigurationItems = new List<IProjectConfigurationItem>();
        }
    }
}

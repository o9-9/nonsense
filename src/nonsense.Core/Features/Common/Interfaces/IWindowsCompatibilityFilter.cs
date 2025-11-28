using System.Collections.Generic;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IWindowsCompatibilityFilter
    {
        IEnumerable<SettingDefinition> FilterSettingsByWindowsVersion(
            IEnumerable<SettingDefinition> settings
        );

        IEnumerable<SettingDefinition> FilterSettingsByWindowsVersion(
            IEnumerable<SettingDefinition> settings,
            bool applyFilter
        );
    }
}

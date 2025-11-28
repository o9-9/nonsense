using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces;

public interface IHardwareCompatibilityFilter
{
    Task<IEnumerable<SettingDefinition>> FilterSettingsByHardwareAsync(IEnumerable<SettingDefinition> settings);
}
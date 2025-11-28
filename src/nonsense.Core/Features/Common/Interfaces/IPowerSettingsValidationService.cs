using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces;

public interface IPowerSettingsValidationService
{
    Task<IEnumerable<SettingDefinition>> FilterSettingsByExistenceAsync(IEnumerable<SettingDefinition> settings);
    Task<bool> IsHibernationEnabledAsync();
}
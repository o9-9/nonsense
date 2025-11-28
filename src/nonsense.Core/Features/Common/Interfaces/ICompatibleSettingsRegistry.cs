using System.Collections.Generic;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface ICompatibleSettingsRegistry
    {
        Task InitializeAsync();
        IEnumerable<SettingDefinition> GetFilteredSettings(string featureId);
        IReadOnlyDictionary<string, IEnumerable<SettingDefinition>> GetAllFilteredSettings();
        IEnumerable<SettingDefinition> GetBypassedSettings(string featureId);
        IReadOnlyDictionary<string, IEnumerable<SettingDefinition>> GetAllBypassedSettings();
        void SetFilterEnabled(bool enabled);
        bool IsInitialized { get; }
    }
}
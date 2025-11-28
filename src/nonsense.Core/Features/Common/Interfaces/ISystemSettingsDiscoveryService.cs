using System.Collections.Generic;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface ISystemSettingsDiscoveryService
    {
        Task<Dictionary<string, Dictionary<string, object?>>> GetRawSettingsValuesAsync(IEnumerable<SettingDefinition> settings);
        Task<Dictionary<string, SettingStateResult>> GetSettingStatesAsync(IEnumerable<SettingDefinition> settings);
    }

    public class SettingStateResult
    {
        public bool IsEnabled { get; set; }
        public object? CurrentValue { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public Dictionary<string, object?>? RawValues { get; set; }
        public bool IsRegistryValueNotSet { get; set; }
    }
}

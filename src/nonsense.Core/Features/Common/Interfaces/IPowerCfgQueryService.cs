using nonsense.Core.Features.Common.Models;
using nonsense.Core.Features.Optimize.Models;

namespace nonsense.Core.Features.Common.Interfaces;

public interface IPowerCfgQueryService
{
    Task<List<PowerPlan>> GetAvailablePowerPlansAsync();
    Task<PowerPlan> GetActivePowerPlanAsync();
    Task<PowerPlan?> GetPowerPlanByGuidAsync(string guid);
    Task<int> GetPowerPlanIndexAsync(string guid, List<string> options);
    Task<int?> GetPowerSettingValueAsync(PowerCfgSetting powerCfgSetting);
    Task<(int? acValue, int? dcValue)> GetPowerSettingACDCValuesAsync(PowerCfgSetting powerCfgSetting);
    Task<Dictionary<string, (int? acValue, int? dcValue)>> GetAllPowerSettingsACDCAsync(string powerPlanGuid = "SCHEME_CURRENT");
    void InvalidateCache();
}
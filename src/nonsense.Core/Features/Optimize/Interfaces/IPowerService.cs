using System.Collections.Generic;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.Optimize.Models;

namespace nonsense.Core.Features.Optimize.Interfaces
{
    public interface IPowerService : IDomainService
    {
        Task<PowerPlan?> GetActivePowerPlanAsync();
        Task<IEnumerable<object>> GetAvailablePowerPlansAsync();
        Task<bool> SetActivePowerPlanAsync(string powerPlanGuid);
        Task<(int acValue, int dcValue)> GetSettingValueAsync(string powerPlanGuid, string subgroupGuid, string settingGuid);
        Task ApplyAdvancedPowerSettingAsync(string powerPlanGuid, string subgroupGuid, string settingGuid, int acValue, int dcValue);
        Task<bool> DeletePowerPlanAsync(string powerPlanGuid);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;
using nonsense.Core.Features.Common.Constants;
using nonsense.Core.Features.Common.Enums;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.Common.Models;
using nonsense.Core.Features.Optimize.Interfaces;
using nonsense.Core.Features.Optimize.Models;
using nonsense.Infrastructure.Features.Common.Services;

namespace nonsense.Infrastructure.Features.Optimize.Services
{
    public class GamingPerformanceService(
        ILogService logService,
        ICompatibleSettingsRegistry compatibleSettingsRegistry) : IDomainService
    {
        public string DomainName => FeatureIds.GamingPerformance;

        public async Task<IEnumerable<SettingDefinition>> GetSettingsAsync()
        {
            try
            {
                return compatibleSettingsRegistry.GetFilteredSettings(FeatureIds.GamingPerformance);
            }
            catch (Exception ex)
            {
                logService.Log(LogLevel.Error, $"Error loading Gaming Performance settings: {ex.Message}");
                return Enumerable.Empty<SettingDefinition>();
            }
        }
    }
}

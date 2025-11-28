using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Constants;
using nonsense.Core.Features.Common.Enums;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.Common.Models;
using nonsense.Core.Features.Optimize.Interfaces;
using nonsense.Core.Features.Optimize.Models;
using nonsense.Infrastructure.Features.Common.Services;

namespace nonsense.Infrastructure.Features.Optimize.Services
{
    public class NotificationService(
        ILogService logService,
        ICompatibleSettingsRegistry compatibleSettingsRegistry) : IDomainService
    {
        public string DomainName => FeatureIds.Notifications;

        public async Task<IEnumerable<SettingDefinition>> GetSettingsAsync()
        {
            try
            {
                return compatibleSettingsRegistry.GetFilteredSettings(FeatureIds.Notifications);
            }
            catch (Exception ex)
            {
                logService.Log(LogLevel.Error, $"Error loading Notifications settings: {ex.Message}");
                return Enumerable.Empty<SettingDefinition>();
            }
        }

    }
}

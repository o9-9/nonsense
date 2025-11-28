using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Constants;
using nonsense.Core.Features.Common.Enums;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.Common.Models;
using nonsense.Core.Features.Customize.Interfaces;
using nonsense.Core.Features.Customize.Models;
using nonsense.Infrastructure.Features.Common.Services;

namespace nonsense.Infrastructure.Features.Customize.Services
{
    public class TaskbarService(
        ILogService logService,
        IWindowsRegistryService windowsRegistryService,
        ICompatibleSettingsRegistry compatibleSettingsRegistry) : IDomainService
    {
        private IEnumerable<SettingDefinition>? _cachedSettings;
        private readonly object _cacheLock = new object();

        public string DomainName => FeatureIds.Taskbar;

        public async Task<IEnumerable<SettingDefinition>> GetSettingsAsync()
        {
            // Return cached settings if available
            if (_cachedSettings != null)
                return _cachedSettings;

            lock (_cacheLock)
            {
                // Double-check locking pattern
                if (_cachedSettings != null)
                    return _cachedSettings;

                try
                {
                    logService.Log(LogLevel.Info, "Loading Taskbar settings");

                    _cachedSettings = compatibleSettingsRegistry.GetFilteredSettings(FeatureIds.Taskbar);
                    return _cachedSettings;
                }
                catch (Exception ex)
                {
                    logService.Log(LogLevel.Error, $"Error loading Taskbar settings: {ex.Message}");
                    return Enumerable.Empty<SettingDefinition>();
                }
            }
        }

        public void ClearSettingsCache()
        {
            lock (_cacheLock)
            {
                _cachedSettings = null;
                logService.Log(LogLevel.Debug, "Taskbar settings cache cleared");
            }
        }

        public async Task CleanTaskbarAsync()
        {
            try
            {
                logService.Log(
                    LogLevel.Info,
                    "Starting Taskbar cleanup - deleting Taskband registry key"
                );

                bool success = windowsRegistryService.DeleteKey(
                    "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband"
                );

                if (success)
                {
                    logService.Log(
                        LogLevel.Success,
                        "Successfully deleted Taskband registry key - Taskbar cleaned"
                    );
                }
                else
                {
                    logService.Log(
                        LogLevel.Warning,
                        "Failed to delete Taskband registry key - may not exist or access denied"
                    );
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logService.Log(LogLevel.Error, $"Error during Taskbar cleanup: {ex.Message}");
                throw;
            }
        }

    }
}

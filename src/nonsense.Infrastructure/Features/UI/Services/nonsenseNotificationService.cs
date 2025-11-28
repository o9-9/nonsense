using System;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.UI.Interfaces;

namespace nonsense.Infrastructure.Features.UI.Services
{
    /// <summary>
    /// Implementation of the notification service that shows toast notifications.
    /// </summary>
    public class nonsenseNotificationService : InonsenseNotificationService
    {
        private readonly ILogService _logService;

        /// <summary>
        /// Initializes a new instance of the <see cref="nonsenseNotificationService"/> class.
        /// </summary>
        /// <param name="logService">The log service.</param>
        public nonsenseNotificationService(ILogService logService)
        {
            _logService = logService;
        }

        /// <inheritdoc/>
        public void ShowToast(string title, string message, ToastType type)
        {
            // Log the notification
            switch (type)
            {
                case ToastType.Information:
                    _logService.LogInformation($"Toast Notification - {title}: {message}");
                    break;
                case ToastType.Success:
                    _logService.LogSuccess($"Toast Notification - {title}: {message}");
                    break;
                case ToastType.Warning:
                    _logService.LogWarning($"Toast Notification - {title}: {message}");
                    break;
                case ToastType.Error:
                    _logService.LogError($"Toast Notification - {title}: {message}");
                    break;
                default:
                    _logService.LogInformation($"Toast Notification - {title}: {message}");
                    break;
            }

            // In a real implementation, this would show a toast notification in the UI
            // For now, we're just logging the notification
        }
    }
}

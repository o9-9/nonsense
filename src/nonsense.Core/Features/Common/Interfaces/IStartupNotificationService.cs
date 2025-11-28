using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IStartupNotificationService
    {
        Task ShowBackupNotificationAsync(BackupResult result);
        void ShowMigrationNotification(ScriptMigrationResult result);
    }
}

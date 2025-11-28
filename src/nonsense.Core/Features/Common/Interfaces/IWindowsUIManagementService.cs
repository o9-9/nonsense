using System.Threading.Tasks;
using nonsense.Core.Features.Common.Enums;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IWindowsUIManagementService
    {
        bool IsConfigImportMode { get; set; }
        void RestartExplorer();
        bool IsProcessRunning(string processName);
        void KillProcess(string processName);
        void RefreshDesktop();
        Task<bool> RefreshWindowsGUI(bool killExplorer = true);
    }
}
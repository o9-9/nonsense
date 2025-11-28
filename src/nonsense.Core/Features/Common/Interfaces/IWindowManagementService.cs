using System.Threading.Tasks;
using nonsense.Core.Features.Common.Enums;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IWindowManagementService
    {
        void MinimizeWindow();
        void MaximizeRestoreWindow();
        Task CloseWindowAsync();
        void HandleWindowStateChanged(WindowState windowState);
        string GetThemeIconPath();
        string GetDefaultIconPath();
        void RequestThemeIconUpdate();
        void ToggleTheme();
    }
}
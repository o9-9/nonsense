using System.Threading.Tasks;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface ISettingApplicationService
    {
        Task ApplySettingAsync(string settingId, bool enable, object? value = null, bool checkboxResult = false, string? commandString = null, bool applyRecommended = false, bool skipValuePrerequisites = false);
    }
}
using System.Threading.Tasks;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IGlobalSettingsPreloader
    {
        Task PreloadAllSettingsAsync();
        bool IsPreloaded { get; }
    }
}

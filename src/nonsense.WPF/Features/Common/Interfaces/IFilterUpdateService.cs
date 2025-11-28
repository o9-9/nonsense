using System.Threading.Tasks;

namespace nonsense.WPF.Features.Common.Interfaces
{
    public interface IFilterUpdateService
    {
        Task UpdateFeatureSettingsAsync(ISettingsFeatureViewModel feature);
    }
}

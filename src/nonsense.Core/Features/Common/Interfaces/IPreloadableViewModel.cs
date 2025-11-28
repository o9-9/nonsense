using System.Threading.Tasks;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IPreloadableViewModel : IFeatureViewModel
    {
        Task PreloadFeaturesAsync();
    }
}
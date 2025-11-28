using System.Threading.Tasks;

namespace nonsense.WPF.Features.Common.Interfaces
{
    public interface IAppFeatureViewModel
    {
        Task LoadItemsAsync();
    }
}
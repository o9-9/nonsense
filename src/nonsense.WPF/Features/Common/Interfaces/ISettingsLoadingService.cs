using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.Core.Features.Common.Models;
using nonsense.WPF.Features.Common.ViewModels;

namespace nonsense.WPF.Features.Common.Interfaces
{
    public interface ISettingsLoadingService
    {
        Task<ObservableCollection<object>> LoadConfiguredSettingsAsync<TDomainService>(
            TDomainService domainService,
            string featureModuleId,
            string progressMessage,
            ISettingsFeatureViewModel? parentViewModel = null)
            where TDomainService : class, IDomainService;

        Task<SettingItemViewModel> CreateSettingViewModelAsync(
            SettingDefinition setting,
            Dictionary<string, SettingStateResult> batchStates,
            ISettingsFeatureViewModel? parentViewModel);
    }
}
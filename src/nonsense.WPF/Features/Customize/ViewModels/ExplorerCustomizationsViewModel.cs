using nonsense.Core.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.ViewModels;

namespace nonsense.WPF.Features.Customize.ViewModels
{
    public partial class ExplorerCustomizationsViewModel(
      IDomainServiceRouter domainServiceRouter,
      ISettingsLoadingService settingsLoadingService,
      ILogService logService)
      : BaseSettingsFeatureViewModel(domainServiceRouter, settingsLoadingService, logService)
    {
        public override string ModuleId => FeatureIds.ExplorerCustomization;
        public override string DisplayName => "Explorer";

    }
}

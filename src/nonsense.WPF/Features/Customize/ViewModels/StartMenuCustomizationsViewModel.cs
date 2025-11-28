using nonsense.Core.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.ViewModels;

namespace nonsense.WPF.Features.Customize.ViewModels
{
    public partial class StartMenuCustomizationsViewModel(
      IDomainServiceRouter domainServiceRouter,
      ISettingsLoadingService settingsLoadingService,
      ILogService logService)
      : BaseSettingsFeatureViewModel(domainServiceRouter, settingsLoadingService, logService)
    {
        public override string ModuleId => FeatureIds.StartMenu;
        public override string DisplayName => "Start Menu";

    }
}

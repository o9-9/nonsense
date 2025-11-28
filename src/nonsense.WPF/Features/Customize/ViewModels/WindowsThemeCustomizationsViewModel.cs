using nonsense.Core.Features.Common.Constants;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.ViewModels;

namespace nonsense.WPF.Features.Customize.ViewModels
{
    public partial class WindowsThemeCustomizationsViewModel(
        IDomainServiceRouter domainServiceRouter,
        ISettingsLoadingService settingsLoadingService,
        ILogService logService)
        : BaseSettingsFeatureViewModel(domainServiceRouter, settingsLoadingService, logService)
    {
        public override string ModuleId => FeatureIds.WindowsTheme;
        public override string DisplayName => "Windows Theme";
    }
}

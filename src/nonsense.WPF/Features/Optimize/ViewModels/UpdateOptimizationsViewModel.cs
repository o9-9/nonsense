using nonsense.Core.Features.Common.Enums;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.Interfaces;
using nonsense.WPF.Features.Common.ViewModels;

namespace nonsense.WPF.Features.Optimize.ViewModels
{
    public partial class UpdateOptimizationsViewModel(
        IDomainServiceRouter domainServiceRouter,
        ISettingsLoadingService settingsLoadingService,
        ILogService logService)
        : BaseSettingsFeatureViewModel(domainServiceRouter, settingsLoadingService, logService)
    {
        public override string ModuleId => FeatureIds.Update;
        public override string DisplayName => "Update";
    }
}

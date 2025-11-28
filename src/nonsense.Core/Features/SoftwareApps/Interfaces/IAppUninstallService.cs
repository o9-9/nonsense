using System;
using System.Threading;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;
using nonsense.Core.Features.SoftwareApps.Models;

namespace nonsense.Core.Features.SoftwareApps.Interfaces;

public interface IAppUninstallService
{
    Task<OperationResult<bool>> UninstallAsync(
        ItemDefinition item,
        IProgress<TaskProgressDetail>? progress = null,
        CancellationToken cancellationToken = default);

    Task<UninstallMethod> DetermineUninstallMethodAsync(ItemDefinition item);
}

public enum UninstallMethod
{
    None,
    WinGet,
    Registry,
    CustomScript
}

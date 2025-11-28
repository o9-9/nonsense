using System;
using System.Threading;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;
using nonsense.Core.Features.SoftwareApps.Models;

namespace nonsense.Core.Features.SoftwareApps.Interfaces;

public interface IDirectDownloadService
{
    Task<bool> DownloadAndInstallAsync(
        ItemDefinition item,
        IProgress<TaskProgressDetail>? progress = null,
        CancellationToken cancellationToken = default);
}

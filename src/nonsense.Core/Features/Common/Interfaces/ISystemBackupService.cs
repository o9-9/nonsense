using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface ISystemBackupService
    {
        Task<BackupResult> EnsureInitialBackupsAsync(
            IProgress<TaskProgressDetail>? progress = null,
            CancellationToken cancellationToken = default);

        Task<BackupStatus> GetBackupStatusAsync();
    }
}

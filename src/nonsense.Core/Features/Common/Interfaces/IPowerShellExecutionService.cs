using System;
using System.Threading;
using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IPowerShellExecutionService
    {
        Task<string> ExecuteScriptAsync(
            string script,
            IProgress<TaskProgressDetail>? progress = null,
            CancellationToken cancellationToken = default);

        Task<bool> ExecuteScriptVisibleAsync(
            string script,
            string windowTitle = "nonsense PowerShell Task");

        Task<string> ExecuteScriptFileAsync(
            string scriptPath,
            string arguments = "",
            IProgress<TaskProgressDetail>? progress = null,
            CancellationToken cancellationToken = default);

        Task<string> ExecuteScriptFileWithProgressAsync(
            string scriptPath,
            string arguments = "",
            IProgress<TaskProgressDetail>? progress = null,
            CancellationToken cancellationToken = default);

        Task<string> ExecuteScriptFromContentAsync(
            string scriptContent,
            IProgress<TaskProgressDetail>? progress = null,
            CancellationToken cancellationToken = default);
    }
}
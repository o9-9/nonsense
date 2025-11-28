using System.Threading.Tasks;
using nonsense.Core.Features.SoftwareApps.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IScheduledTaskService
    {
        Task<bool> RegisterScheduledTaskAsync(RemovalScript script);
        Task<bool> UnregisterScheduledTaskAsync(string taskName);
        Task<bool> IsTaskRegisteredAsync(string taskName);
        Task<bool> CreateUserLogonTaskAsync(string taskName, string command, string username, bool deleteAfterRun = true);
    }
}
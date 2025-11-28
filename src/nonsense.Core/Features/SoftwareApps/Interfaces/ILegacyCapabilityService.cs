using System.Threading;
using System.Threading.Tasks;

namespace nonsense.Core.Features.SoftwareApps.Interfaces;

public interface ILegacyCapabilityService
{
    Task<bool> EnableCapabilityAsync(string capabilityName, string displayName = null, CancellationToken cancellationToken = default);
    Task<bool> DisableCapabilityAsync(string capabilityName, string displayName = null, CancellationToken cancellationToken = default);
}
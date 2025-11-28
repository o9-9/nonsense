using System.Collections.Generic;
using System.Threading.Tasks;
using nonsense.Core.Features.SoftwareApps.Models;

namespace nonsense.Core.Features.SoftwareApps.Interfaces;

public interface IAppDomainService
{
    string DomainName { get; }
    Task<IEnumerable<ItemDefinition>> GetAppsAsync();
}
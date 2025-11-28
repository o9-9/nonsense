using System.Collections.Generic;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IDomainServiceRouter
    {
        IDomainService GetDomainService(string featureIdOrSettingId);
        void AddSettingMappings(string featureId, IEnumerable<string> settingIds);
        void ClearAllSettingsCaches();
    }
}

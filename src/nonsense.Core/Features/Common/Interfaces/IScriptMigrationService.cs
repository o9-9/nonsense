using System.Threading.Tasks;
using nonsense.Core.Features.Common.Models;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IScriptMigrationService
    {
        Task<ScriptMigrationResult> MigrateFromOldPathsAsync();
    }
}

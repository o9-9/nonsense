using System.Collections.Generic;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IScriptDetectionService
    {
        bool AreRemovalScriptsPresent();
        IEnumerable<ScriptInfo> GetActiveScripts();
    }

    public class ScriptInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
    }
}

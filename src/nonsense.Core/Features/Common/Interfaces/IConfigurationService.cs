using System.Threading.Tasks;

namespace nonsense.Core.Features.Common.Interfaces
{
    public interface IConfigurationService
    {
        Task ExportConfigurationAsync();
        Task ImportConfigurationAsync();
        Task ImportRecommendedConfigurationAsync();
    }
}

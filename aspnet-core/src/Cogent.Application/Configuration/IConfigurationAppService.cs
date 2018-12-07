using System.Threading.Tasks;
using Cogent.Configuration.Dto;

namespace Cogent.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

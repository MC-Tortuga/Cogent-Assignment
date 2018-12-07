using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Cogent.Configuration.Dto;

namespace Cogent.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CogentAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

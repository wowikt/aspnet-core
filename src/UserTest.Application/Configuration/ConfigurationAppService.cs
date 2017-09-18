using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using UserTest.Configuration.Dto;

namespace UserTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : UserTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

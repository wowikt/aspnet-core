using System.Threading.Tasks;
using UserTest.Configuration.Dto;

namespace UserTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
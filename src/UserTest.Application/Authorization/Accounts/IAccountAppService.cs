using System.Threading.Tasks;
using Abp.Application.Services;
using UserTest.Authorization.Accounts.Dto;

namespace UserTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

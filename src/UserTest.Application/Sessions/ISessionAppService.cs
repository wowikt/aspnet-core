using System.Threading.Tasks;
using Abp.Application.Services;
using UserTest.Sessions.Dto;

namespace UserTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

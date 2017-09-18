using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UserTest.Roles.Dto;
using UserTest.Users.Dto;

namespace UserTest.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
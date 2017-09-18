using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UserTest.MultiTenancy.Dto;

namespace UserTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

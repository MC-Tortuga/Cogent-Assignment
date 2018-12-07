using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Cogent.MultiTenancy.Dto;

namespace Cogent.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

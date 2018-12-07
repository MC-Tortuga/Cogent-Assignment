using System.Threading.Tasks;
using Abp.Application.Services;
using Cogent.Authorization.Accounts.Dto;

namespace Cogent.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

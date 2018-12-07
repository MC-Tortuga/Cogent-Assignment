using System.Threading.Tasks;
using Abp.Application.Services;
using Cogent.Sessions.Dto;

namespace Cogent.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

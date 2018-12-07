using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Cogent.Calls.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cogent.Calls
{
    public interface ICallApplicationService: IAsyncCrudAppService<CallDto, int ,PagedResultRequestDto>
    {
    }
}

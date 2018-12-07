using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cogent.Calls.Dto
{
    [AutoMap(typeof(Call))]
    public class CallDto:EntityDto<int>
    {
        public string CallNumber{ get; set; }
        public string Description { get; set; }
        public long UserId{ get; set; }
    }
}

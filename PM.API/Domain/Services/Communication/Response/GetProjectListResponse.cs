using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class GetProjectListResponse : BaseResponse<List<ProjectResource>>
    {
        public GetProjectListResponse(List<ProjectResource> resource) : base(resource)
        { }
        public GetProjectListResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}

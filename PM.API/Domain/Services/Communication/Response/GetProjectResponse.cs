using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class GetProjectResponse : BaseResponse<ProjectDetailResource>
    {
        public GetProjectResponse(ProjectDetailResource resource) : base(resource)
        { }
        public GetProjectResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}

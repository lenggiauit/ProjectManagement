using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class RegisterResponse : BaseResponse<RegisterResource>
    {
        public RegisterResponse(RegisterResource resource) : base(resource)
        { }
        public RegisterResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
        public RegisterResponse(bool success) : base(success)
        { }
    } 
}

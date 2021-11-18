using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class AuthenticateResponse : BaseResponse<UserResource>
    {
        public AuthenticateResponse(UserResource resource) : base(resource)
        { }
        public AuthenticateResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
        public AuthenticateResponse(bool success) : base(success)
        { }
    }
}
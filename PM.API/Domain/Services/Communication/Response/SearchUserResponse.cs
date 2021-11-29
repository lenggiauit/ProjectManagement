using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class SearchUserResponse : BaseResponse<List<ConversationerResource>>
    {
        public SearchUserResponse(List<ConversationerResource> resource) : base(resource)
        { }
        public SearchUserResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}

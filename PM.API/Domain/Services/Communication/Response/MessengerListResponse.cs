using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class MessengerListResponse : BaseResponse<List<ConversationerResource>>
    {
        public MessengerListResponse(List<ConversationerResource> resource) : base(resource)
        { }
        public MessengerListResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}

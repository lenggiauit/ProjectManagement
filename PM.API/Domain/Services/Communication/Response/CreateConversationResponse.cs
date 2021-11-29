using PM.API.Domain.Helpers;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services.Communication.Response
{
    public class CreateConversationResponse : BaseResponse<ConversationResource>
    { 
        public CreateConversationResponse(ConversationResource resource) : base(resource)
        { } 
        public CreateConversationResponse(string message) : base(message)
        { }
        public CreateConversationResponse(string message, ResultCode resultCode) : base(message, resultCode)
        { }
    }
}
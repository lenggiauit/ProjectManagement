using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<List<Conversation>> GetConversationListByUser(Guid userId, BaseRequest<GetConversationListRequest> request);
        
        Task<Conversation> CreateConversation(Guid userId, BaseRequest<CreateConversationRequest> request);
        Task<ResultCode> InviteToConversation(BaseRequest<InviteConversationRequest> request);
        Task<ConversationMessage> SendMessage(Guid userId, BaseRequest<SendMessageRequest> request);
        Task SaveMessage(Guid userId, Guid conversationId, string message);
        Task<List<ConversationMessage>> GetMessagesByConversation(object userId, BaseRequest<GetMessagesRequest> request);
        Task<List<Conversation>> ConversationalSearch(User currentUser, BaseRequest<ConversationalSearchRequest> request);
        Task<ResultCode> DeleteConversation(Guid userId, BaseRequest<Guid> request);
        Task<List<User>> MessengerSearch(User user, BaseRequest<MessengerSearchRequest> request);
        Task<ResultCode> RemoveFromConversation(Guid userId, BaseRequest<RemoveFromConversationRequest> request);
        Task DeleteMessage(Guid userId, Guid coversationId, Guid messageId);
    }
}

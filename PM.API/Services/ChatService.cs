using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Repositories;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly ILogger<ChatService> _logger;

        public ChatService(IChatRepository chatRepository, ILogger<ChatService> logger, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _chatRepository = chatRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<Conversation> CreateConversation(Guid userId, BaseRequest<CreateConversationRequest> request)
        {
            return await _chatRepository.CreateConversation(userId, request); 
        }

        public async Task<List<Conversation>> GetConversationListByUser(Guid userId, BaseRequest<GetConversationListRequest> request)
        {
            return await _chatRepository.GetConversationListByUser(userId, request);
        }

        public async Task<List<ConversationMessage>> GetMessagesByConversation(Guid userId, BaseRequest<GetMessagesRequest> request)
        {
            return await _chatRepository.GetMessagesByConversation(userId, request);
        }

        public async Task<ResultCode> InviteToConversation(BaseRequest<InviteConversationRequest> request)
        {
            return await _chatRepository.InviteToConversation(request);
        }

        public async Task SaveMessage(Guid userId, Guid conversationId, string message)
        {
            await _chatRepository.SaveMessage(userId, conversationId, message);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<User>> SearchConversationer(BaseRequest<SearchConversationerRequest> request)
        {
            return await _chatRepository.SearchConversationer(request);
        }

        public async Task<ConversationMessage> SendMessage(Guid userId, BaseRequest<SendMessageRequest> request)
        {
            return await _chatRepository.SendMessage(userId, request);
        }
    }
}

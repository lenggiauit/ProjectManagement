﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Request;
using PM.API.Domain.Services.Communication.Response;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PM.API.Services
{
    [Authorize]
    public class ConversationServiceHub : Hub
    {
        private readonly IChatService _chatServices; 
        private readonly ILogger<ConversationServiceHub> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper; 

        public ConversationServiceHub(
            ILogger<ConversationServiceHub> logger,
            IMapper mapper,
            IChatService ChatServices,
           
            IOptions<AppSettings> appSettings) : base()
        {
            _chatServices = ChatServices; 
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
       
        private readonly static ChatConnectionMapping<Guid> _chatConnections = new ChatConnectionMapping<Guid>(); 
        public Guid GetCurrentUserId()
        {
            var claimUser = Context.User.Claims.Where(c => c.Type == ClaimTypes.UserData).FirstOrDefault();
            if (claimUser != null)
            {
                User userResource = JsonConvert.DeserializeObject<User>(claimUser.Value);
                return userResource.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public async Task CheckConnectionStatus(Guid userId)
        {
            await Clients.Group(userId.ToString().Trim()).SendAsync("onCheckConnectionStatus", "[Connected]");
        } 

        public async Task StartConversation(Guid conversationId, string jsonConversation)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString().Trim());
            try
            {
                var convResource =  JsonConvert.DeserializeObject<ConversationResource>(jsonConversation);
                if(convResource != null)
                {
                    //BaseRequest<CreateConversationRequest> request = new BaseRequest<CreateConversationRequest>() {  Payload = new CreateConversationRequest{
                    //    Id = conversationId,
                    //    Users = convResource.Conversationers.Select( u => u.Id).ToArray()
                    //} };
                    //await _chatServices.CreateConversation(GetCurrentUserId(), request);
                    foreach (var user in convResource.Conversationers)
                    {
                        await Clients.Group(user.Id.ToString().Trim()).SendAsync("onStartConversation", jsonConversation);
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task SendMessage(string jsonConversation)
        { 
            try
            {
                var convMessageResource = JsonConvert.DeserializeObject<ConversationMessageResource>(jsonConversation);
                if (convMessageResource != null)
                {  
                    await Clients.Group(convMessageResource.ConversationId.ToString().Trim()).SendAsync("onReceivedMessage", jsonConversation);
                    await Clients.Group(convMessageResource.ConversationId.ToString().Trim()).SendAsync("onConversationReceivedMessage", jsonConversation);
                    await _chatServices.SaveMessage(GetCurrentUserId(), convMessageResource.ConversationId, convMessageResource.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
         

        public async Task OnTyping(Guid conversationId, Guid userId)
        {
            await Clients.Group(conversationId.ToString().Trim()).SendAsync("onUserTyping", conversationId.ToString().Trim(), userId.ToString().Trim());
            await Clients.Group(conversationId.ToString().Trim()).SendAsync("onConversationTyping", conversationId.ToString().Trim(), userId.ToString().Trim());
        }
        public async Task OnInviting(Guid conversationId, Guid userId)
        {
            await Clients.Group(conversationId.ToString().Trim()).SendAsync("onInviting", userId.ToString().Trim());
        }
        public async Task AddToConversationGroup(Guid conversationId)
        { 
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString().Trim()); 
        }
        public async Task RemoveFromConversationGroup(Guid conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString().Trim()); 
        }
         
        public override Task OnConnectedAsync()
        {
             Groups.AddToGroupAsync(Context.ConnectionId, GetCurrentUserId().ToString().Trim());
            _chatConnections.Add(GetCurrentUserId(), Context.ConnectionId); 
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
             Groups.RemoveFromGroupAsync(Context.ConnectionId, GetCurrentUserId().ToString().Trim());
            _chatConnections.Remove(GetCurrentUserId(), Context.ConnectionId); 
            return base.OnDisconnectedAsync(exception);
        }

    }
}

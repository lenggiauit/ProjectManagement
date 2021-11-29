﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Repositories;
using PM.API.Domain.Services.Communication.Request;
using PM.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Persistence.Repositories
{
    public class ChatRepository : BaseRepository, IChatRepository
    {
        private readonly ILogger<ChatRepository> _logger;
        public ChatRepository(PMContext context, ILogger<ChatRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<Conversation> CreateConversation(Guid userId, BaseRequest<CreateConversationRequest> request)
        {
            try
            {
                var conversation = new Conversation()
                {
                    Id = Guid.NewGuid(),
                    Title = request.Payload.Title,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now
                };
                await _context.Conversation.AddAsync(conversation);
                List<ConversationUsers> listc = new List<ConversationUsers>();

                foreach (var id in request.Payload.Users)
                {
                    listc.Add(new ConversationUsers()
                    {
                        Id = Guid.NewGuid(),
                        ConversationId = conversation.Id,
                        UserId = id
                    });
                }
                // add current user
                listc.Add(new ConversationUsers()
                {
                    Id = Guid.NewGuid(),
                    ConversationId = conversation.Id,
                    UserId = userId
                });

                await _context.ConversationUsers.AddRangeAsync(listc);
                await _context.SaveChangesAsync();
                return conversation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<ResultCode> InviteToConversation(BaseRequest<InviteConversationRequest> request)
        {
            try
            {
                List<ConversationUsers> listc = new List<ConversationUsers>();

                foreach (var id in request.Payload.Users)
                {
                    listc.Add(new ConversationUsers()
                    {
                        Id = Guid.NewGuid(),
                        ConversationId = request.Payload.ConversationId,
                        UserId = id
                    });
                }
                await _context.ConversationUsers.AddRangeAsync(listc);
                await _context.SaveChangesAsync();
                return ResultCode.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ResultCode.Error;
            }
        }

        public async Task<List<Conversation>> GetConversationListByUser(Guid userId, BaseRequest<GetConversationListRequest> request)
        {
            try
            {
                return await _context.Conversation.OrderByDescending(s => s.UpdatedBy).Join(_context.ConversationUsers.Where(cu => cu.UserId.Equals(userId)),
                    c => c.Id,
                    cus => cus.ConversationId,
                    (c, cus) => new Conversation()
                    {
                        Id = c.Id,
                        Title = c.Title,
                        LastMessage = c.LastMessage,
                        CreatedBy = c.CreatedBy,
                        CreatedDate = c.CreatedDate,
                        UpdatedBy = c.UpdatedBy,
                        LastMessageDate = c.LastMessageDate,
                        Conversationers = _context.ConversationUsers.Where(cus2 => cus2.ConversationId.Equals(c.Id))
                        .Join(_context.User, cus2 => cus2.UserId, u => u.Id, (cus2, u) => new User()
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            Email = u.Email,
                            Avatar = u.Avatar,
                            FullName = u.FullName,
                            Phone = u.Phone,
                            Address = u.Address,
                            JobTitle = u.JobTitle, 
                            Role = _context.Role.Where(r => r.Id == u.RoleId).FirstOrDefault() 
                        }) 
                        .ToList()
                    })
                    .AsNoTracking().GetPagingQueryable(request.MetaData).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public async Task<List<User>> SearchConversationer(BaseRequest<SearchConversationerRequest> request)
        {
            try
            {
                return await _context.User.AsNoTracking()
                    .Where(u =>
                        u.FullName.Contains(request.Payload.Keyword) ||
                        u.UserName.Contains(request.Payload.Keyword) ||
                        u.Email.Contains(request.Payload.Keyword))
                    .Select(acc => new User()
                    {
                        Id = acc.Id,
                        UserName = acc.UserName,
                        Avatar = acc.Avatar,
                        FullName = acc.FullName,
                        Phone = acc.Phone,
                        Address = acc.Address,
                        JobTitle = acc.JobTitle,
                        Role = _context.Role.Where(r => r.Id == acc.RoleId).FirstOrDefault()
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<ConversationMessage> SendMessage(Guid userId, BaseRequest<SendMessageRequest> request)
        {
            try
            {
                var message = new ConversationMessage()
                {
                    Id = Guid.NewGuid(),
                    ConversationId = request.Payload.ConversationId,
                    UserId  = userId,
                    SendDate = DateTime.Now,
                    Message = request.Payload.Message
                };
                await _context.ConversationMessage.AddAsync(message); 
                await _context.SaveChangesAsync();
                return message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task SaveMessage(Guid userId, Guid conversationId, string message)
        {
            try
            {
                var convMessage = new ConversationMessage()
                {
                    Id = Guid.NewGuid(),
                    ConversationId = conversationId,
                    UserId = userId,
                    SendDate = DateTime.Now,
                    Message = message
                };
                await _context.ConversationMessage.AddAsync(convMessage); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message); 
            }
        }

        public async Task<List<ConversationMessage>> GetMessagesByConversation(object userId, BaseRequest<GetMessagesRequest> request)
        {
            try
            {
                return await _context.ConversationMessage.OrderByDescending(s => s.SendDate).Where( cm => cm.ConversationId.Equals(request.Payload.ConversationId)) 
                    .AsNoTracking().GetPagingQueryable(request.MetaData).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
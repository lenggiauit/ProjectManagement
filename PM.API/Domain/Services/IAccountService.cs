﻿using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services.Communication.Request; 
using System; 
using System.Threading.Tasks;

namespace PM.API.Domain.Services
{
    public interface IAccountService
    {
        Task<User> GetById(Guid id);
        Task<User> Login(string name, string password);
        Task<User> LoginWithGoogle(string email);
        Task<ResultCode> Register(string name, string email, string password);
        Task<ResultCode> CheckEmail(string email);
        Task<ResultCode> CheckUserName(string userName);
        Task<ResultCode> ForgotPassword(string email);
        Task<ResultCode> ResetPassword(string userInfo, string newPassword);
        Task<ResultCode> UpdateProfile(Guid userId, BaseRequest<UpdateProfileRequest> request);
        Task<ResultCode> UpdateUserAvatar(Guid userId,BaseRequest<UpdateUserAvatarRequest> request);
        Task<ResultCode> CheckEmailWithUser(string email, Guid id);
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Request;
using PM.API.Domain.Services.Communication.Response;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountServices;
        private readonly IHttpClientFactoryService _httpClientFactoryService;
        private readonly ILogger<AccountController> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            IAccountService accountService,
            IHttpClientFactoryService httpClientFactoryService,
            IOptions<AppSettings> appSettings)
        {
            _accountServices = accountService;
            _httpClientFactoryService = httpClientFactoryService;
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value; 
        }

        [HttpPost("Login")]
        public async Task<AuthenticateResponse> Login([FromBody] BaseRequest<AuthenticateRequest> request)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountServices.Login( request.Payload.Name, request.Payload.Password );
                if (user != null)
                {
                    var resources = _mapper.Map<User, UserResource>(user);
                    AccessToken accessToken = new AccessToken(); 
                    resources.AccessToken = accessToken.GenerateToken(resources, _appSettings.Secret); 
                    return new AuthenticateResponse(resources);
                }
                else
                {
                    return new AuthenticateResponse(Constants.InvalidMsg, ResultCode.NotExistUser);
                }
            }
            else
            {
                return new AuthenticateResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }
         
        [HttpGet("LoginWithGoogle")]
        public async Task<AuthenticateResponse> LoginWithGoogle(string access_token)
        {
            try
            {
                var googleApiResponse = _httpClientFactoryService.GetAsync(string.Format(_appSettings.GoogleapisUrl, access_token)).Result;
                if (googleApiResponse != null)
                {
                    var user = await _accountServices.LoginWithGoogle(googleApiResponse["email"].ToString());
                    if (user != null)
                    {
                        var resources = _mapper.Map<User, UserResource>(user);
                        AccessToken accessToken = new AccessToken(); 
                        resources.AccessToken = accessToken.GenerateToken(resources, _appSettings.Secret); 
                        return new AuthenticateResponse(resources);
                    }
                    else
                    {
                        return new AuthenticateResponse(Constants.InvalidMsg, ResultCode.Error);
                    }
                }
                else
                {
                    return new AuthenticateResponse(Constants.InvalidMsg, ResultCode.Unknown);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new AuthenticateResponse(Constants.InvalidMsg, ResultCode.Error);
            }
        }
          
        [HttpPost("Register")]
        public async Task<RegisterResponse> Register([FromBody] BaseRequest<RegisterRequest> request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.Register(request.Payload.UserName, request.Payload.Email, request.Payload.Password);
                return new RegisterResponse(string.Empty, result);
            }
            else
            {
                return new RegisterResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }

        [HttpGet("RegisterWithGoogle")]
        public async Task<RegisterResponse> RegisterWithGoogle(string access_token)
        {  
            try
            {
               var googleApiResponse = _httpClientFactoryService.GetAsync(string.Format(_appSettings.GoogleapisUrl, access_token)).Result;
               if(googleApiResponse != null)
                {
                    var result = await _accountServices.Register(googleApiResponse["email"].ToString(), googleApiResponse["email"].ToString(), string.Empty);
                    return new RegisterResponse(string.Empty, result); 
                }
                else
                {
                    return new RegisterResponse(Constants.InvalidMsg, ResultCode.Unknown);
                } 
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new RegisterResponse(Constants.InvalidMsg, ResultCode.Error);
            }
        }
           
        [HttpGet("CheckEmail")]
        public async Task<RegisterResponse> CheckEmail(string email)
        { 
            var result = await _accountServices.CheckEmail(email);
            return new RegisterResponse(string.Empty, result); 
        }

        [HttpGet("CheckUserName")]
        public async Task<RegisterResponse> CheckUserName(string name)
        {
            var result = await _accountServices.CheckUserName(name);
            return new RegisterResponse(string.Empty, result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<CommonResponse> ForgotPassword([FromBody] BaseRequest<ForgotPasswordRequest> request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.ForgotPassword(request.Payload.Email);
                return new CommonResponse(string.Empty, result);
            }
            else
            {
                return new CommonResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<CommonResponse> ResetPassword([FromBody] BaseRequest<ResetPasswordRequest> request)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.ResetPassword(request.Payload.UserInfo, request.Payload.NewPassword);
                return new CommonResponse(string.Empty, result);
            }
            else
            {
                return new CommonResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        } 

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Request;
using PM.API.Domain.Services.Communication.Response;
using PM.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Authorize]
    [Route("Team")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamServices; 
        private readonly ILogger<TeamController> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        public TeamController(
            ILogger<TeamController> logger,
            IMapper mapper,
            ITeamService teamServices, 
            IOptions<AppSettings> appSettings)
        {
            _teamServices = teamServices; 
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [Permissions("GetTeamList")]
        [HttpPost("GetTeamList")]
        public async Task<GetTeamListResponse> GetTeamList([FromBody] BaseRequest<GetTeamListRequest> request)
        {
            if (ModelState.IsValid)
            {
                var teamList = await _teamServices.GetTeamList(request) ;
                var resources = _mapper.Map<List<Team>, List<TeamResource>>(teamList);
                return new GetTeamListResponse(resources); 
            }
            else
            {
                return new GetTeamListResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }
        [Permissions("GetTeamListByUser")]
        [HttpPost("GetTeamListByUser")]
        public async Task<GetTeamListResponse> GetTeamListByUser([FromBody] BaseRequest<GetTeamListRequest> request)
        {
            if (ModelState.IsValid)
            {
                var teamList = await _teamServices.GetTeamListByUser(request);
                var resources = _mapper.Map<List<Team>, List<TeamResource>>(teamList);
                return new GetTeamListResponse(resources);
            }
            else
            {
                return new GetTeamListResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }
        [Permissions("GetTeamListByProject")]
        [HttpPost("GetTeamListByProject")]
        public async Task<GetTeamListResponse> GetTeamListByProject([FromBody] BaseRequest<GetTeamListRequest> request)
        {
            if (ModelState.IsValid)
            {
                var teamList = await _teamServices.GetTeamListByProject(request);
                var resources = _mapper.Map<List<Team>, List<TeamResource>>(teamList);
                return new GetTeamListResponse(resources);
            }
            else
            {
                return new GetTeamListResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }


    }
}

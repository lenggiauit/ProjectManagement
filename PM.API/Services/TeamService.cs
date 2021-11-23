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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository; 
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly ILogger<AccountService> _logger;

        public TeamService(ITeamRepository teamRepository,  ILogger<AccountService> logger, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _teamRepository = teamRepository; 
            _logger = logger;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<ResultCode> CreateTeam(CreateTeamRequest createTeamRequest)
        {
            await _teamRepository.CreateTeam(createTeamRequest);
            await _unitOfWork.CompleteAsync();
            return ResultCode.Success;
        }

        public async Task<Team> GetById(Guid id)
        {
            return await _teamRepository.GetById(id);
        }

        public async Task<List<Team>> GetTeamList(BaseRequest<GetTeamListRequest> getTeamListRequest)
        {
            return await _teamRepository.GetTeamList(getTeamListRequest);
        }

        public async Task<List<Team>> GetTeamListByProject(BaseRequest<GetTeamListRequest> getTeamListRequest)
        {
            return await _teamRepository.GetTeamListByProject(getTeamListRequest);
        }

        public async Task<List<Team>> GetTeamListByUser(BaseRequest<GetTeamListRequest> getTeamListRequest)
        {
            return await _teamRepository.GetTeamListByUser(getTeamListRequest);
        }

        public async Task<ResultCode> Update(UpdateTeamRequest updateTeamRequest)
        {
            await _teamRepository.Update(updateTeamRequest);
            await _unitOfWork.CompleteAsync();
            return ResultCode.Success;
        }
    }
}

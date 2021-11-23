using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Repositories
{
     public interface ITeamRepository
    {
        Task<Team> GetById(Guid id);
        Task<bool> CreateTeam(CreateTeamRequest createTeamRequest);
        Task<bool> Update(UpdateTeamRequest updateTeamRequest);
        Task<List<Team>> GetTeamList(BaseRequest<GetTeamListRequest> teamListRequest);
        Task<List<Team>> GetTeamListByUser(BaseRequest<GetTeamListRequest> teamListRequest);
        Task<List<Team>> GetTeamListByProject(BaseRequest<GetTeamListRequest> teamListRequest);
    }
}

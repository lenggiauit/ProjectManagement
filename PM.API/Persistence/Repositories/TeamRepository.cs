using Microsoft.EntityFrameworkCore;
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
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public TeamRepository(PMContext context) : base(context) { }
    
        public async Task<bool> CreateTeam(CreateTeamRequest createTeamRequest)
        {
            Team newTeam = new Team()
            {
                Id = Guid.NewGuid(),
                Name = createTeamRequest.Name,
                Description = createTeamRequest.Description,
                IsPublic = createTeamRequest.IsPublic, 
                CreatedDate = DateTime.Now,
                CreatedBy = Guid.Empty,
            };
            await _context.Team.AddAsync(newTeam); 
            return true;
        }

        public async Task<Team> GetById(Guid id)
        {
            return await _context.Team.AsNoTracking().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Team>> GetTeamList(BaseRequest<GetTeamListRequest> teamListRequest)
        {
            return await _context.Team.AsNoTracking().GetPagingQueryable(teamListRequest.MetaData).ToListAsync();
        }

        public async Task<List<Team>> GetTeamListByProject(BaseRequest<GetTeamListRequest> teamListRequest)
        {
            return await _context.Team.AsNoTracking().GetPagingQueryable(teamListRequest.MetaData).ToListAsync();
        }

        public async Task<List<Team>> GetTeamListByUser(BaseRequest<GetTeamListRequest> teamListRequest)
        {
            return await _context.Team.AsNoTracking().GetPagingQueryable(teamListRequest.MetaData).ToListAsync();
        }

        public async Task<bool> Update(UpdateTeamRequest updateTeamRequest)
        {
            var team = await _context.Team.Where(u => u.Id.Equals(updateTeamRequest.Id)).FirstOrDefaultAsync();
            if (team != null)
            {
                team.Name = updateTeamRequest.Name;
                team.Description = updateTeamRequest.Description;
                _context.Update(team);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

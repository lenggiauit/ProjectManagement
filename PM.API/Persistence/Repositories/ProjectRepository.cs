using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PM.API.Domain.Entities;
using PM.API.Domain.Repositories;
using PM.API.Domain.Services.Communication.Request;
using PM.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        private readonly ILogger<ProjectRepository> _logger;
        public ProjectRepository(PMContext context, ILogger<ProjectRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<bool> CreateProject(CreateProjectRequest createProjectRequest)
        {
            try
            {
                Project newProject = new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = createProjectRequest.Name,
                    Description = createProjectRequest.Description,
                    StatusId = createProjectRequest.StatusId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = Guid.Empty,
                };
                await _context.Project.AddAsync(newProject);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Project> GetById(Guid id)
        {
            try
            {
                return await _context.Project.AsNoTracking().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Project>> GetProjectList(BaseRequest<GetProjectListRequest> ProjectListRequest)
        {
            try
            {
                return await _context.Project.AsNoTracking().GetPagingQueryable(ProjectListRequest.MetaData).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Project>> GetProjectListByProject(BaseRequest<GetProjectListRequest> ProjectListRequest)
        {
            try
            {
                return await _context.Project.AsNoTracking().GetPagingQueryable(ProjectListRequest.MetaData).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<List<Project>> GetProjectListByUser(BaseRequest<GetProjectListRequest> ProjectListRequest)
        {
            try
            {
                return await _context.Project.AsNoTracking().GetPagingQueryable(ProjectListRequest.MetaData).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> Update(UpdateProjectRequest updateProjectRequest)
        {
            try
            {
                var project = await _context.Project.Where(u => u.Id.Equals(updateProjectRequest.Id)).FirstOrDefaultAsync();
                if (project != null)
                {
                    project.Name = updateProjectRequest.Name;
                    project.Description = updateProjectRequest.Description;
                    project.StatusId = updateProjectRequest.StatusId;
                    _context.Update(project);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
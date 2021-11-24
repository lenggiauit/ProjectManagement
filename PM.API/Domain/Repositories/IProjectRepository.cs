using PM.API.Domain.Entities;
using PM.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetById(Guid id);
        Task<bool> CreateProject(CreateProjectRequest createProjectRequest);
        Task<bool> Update(UpdateProjectRequest updateProjectRequest);
        Task<List<Project>> GetProjectList(BaseRequest<GetProjectListRequest> ProjectListRequest);
        Task<List<Project>> GetProjectListByUser(BaseRequest<GetProjectListRequest> ProjectListRequest);
    }
}

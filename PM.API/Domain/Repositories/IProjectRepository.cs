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
        Task<bool> CreateProject(Guid userId, CreateProjectRequest request);
        Task<bool> Update(Guid userId, UpdateProjectRequest request);
        Task<List<Project>> GetProjectList(Guid userId, BaseRequest<GetProjectListRequest> request);
        Task<List<Project>> GetProjectListByUser(Guid userId, BaseRequest<GetProjectListRequest> request);
        Task<Project> GetProjectDetailById(object userId, BaseRequest<Guid> request);
    }
}

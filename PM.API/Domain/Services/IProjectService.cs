using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services
{
    public interface IProjectService
    {
        Task<Project> GetById(Guid id);
        Task<ResultCode> CreateProject(CreateProjectRequest createProjectRequest);
        Task<ResultCode> Update(UpdateProjectRequest updateProjectRequest);
        Task<List<Project>> GetProjectList(BaseRequest<GetProjectListRequest> getProjectListRequest);
        Task<List<Project>> GetProjectListByUser(BaseRequest<GetProjectListRequest> getProjectListRequest); 
    }
}

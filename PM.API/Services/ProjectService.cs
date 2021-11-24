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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IProjectRepository projectRepository, ILogger<ProjectService> logger, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _projectRepository = projectRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        public async Task<ResultCode> CreateProject(CreateProjectRequest createProjectRequest)
        {
            await _projectRepository.CreateProject(createProjectRequest);
            await _unitOfWork.CompleteAsync();
            return ResultCode.Success;
        }

        public async Task<Project> GetById(Guid id)
        {
            return await _projectRepository.GetById(id);
        }

        public async Task<List<Project>> GetProjectList(BaseRequest<GetProjectListRequest> getprojectListRequest)
        {
            return await _projectRepository.GetProjectList(getprojectListRequest);
        }

        
        public async Task<List<Project>> GetProjectListByUser(BaseRequest<GetProjectListRequest> getprojectListRequest)
        {
            return await _projectRepository.GetProjectListByUser(getprojectListRequest);
        }

        public async Task<ResultCode> Update(UpdateProjectRequest updateprojectRequest)
        {
            await _projectRepository.Update(updateprojectRequest);
            await _unitOfWork.CompleteAsync();
            return ResultCode.Success;
        }
    }
}

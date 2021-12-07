﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.API.Domain.Entities;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Request;
using PM.API.Domain.Services.Communication.Response;
using PM.API.Infrastructure;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Authorize]
    [Route("Project")]
    public class ProjectController : PMBaseController
    {
        private readonly IProjectService _projectServices;
        private readonly ILogger<ProjectController> _logger;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        public ProjectController(
            ILogger<ProjectController> logger,
            IMapper mapper,
            IProjectService projectServices,
            IOptions<AppSettings> appSettings)
        {
            _projectServices = projectServices;
            _logger = logger;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [Permissions("GetProjectList")]
        [HttpPost("GetProjectList")]
        public async Task<GetProjectListResponse> GetProjectList([FromBody] BaseRequest<GetProjectListRequest> request)
        {
            if (ModelState.IsValid)
            {
                var projectList = await _projectServices.GetProjectList(GetCurrentUserId(), request);
                var resources = _mapper.Map<List<Project>, List<ProjectResource>>(projectList);
                return new GetProjectListResponse(resources);
            }
            else
            {
                return new GetProjectListResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }

        [Permissions(PermissionConstant.GetProjectListByUser)]
        [HttpPost("GetProjectListByUser")]
        public async Task<GetProjectListResponse> GetProjectListByUser([FromBody] BaseRequest<GetProjectListRequest> request)
        {
            if (ModelState.IsValid)
            {
                var projectList = await _projectServices.GetProjectListByUser(GetCurrentUserId(), request);
                var resources = _mapper.Map<List<Project>, List<ProjectResource>>(projectList);
                return new GetProjectListResponse(resources);
            }
            else
            {
                return new GetProjectListResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }

        //[Permissions(PermissionConstant.GetProjectDetail)]
        [HttpPost("GetProjectDetailById")]
        public async Task<GetProjectResponse> GetProjectDetailById([FromBody] BaseRequest<Guid> request)
        {
            if (ModelState.IsValid)
            {
                var project = await _projectServices.GetProjectDetailById(GetCurrentUserId(), request);
                var resources = _mapper.Map<Project, ProjectDetailResource>(project);
                return new GetProjectResponse(resources);
            }
            else
            {
                return new GetProjectResponse(Constants.InvalidMsg, ResultCode.Invalid);
            }
        }

        


    }
}

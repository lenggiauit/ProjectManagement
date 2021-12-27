﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.API.Domain.Helpers;
using PM.API.Domain.Models;
using PM.API.Domain.Repositories;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Services
{
    public class RefService : IRefService
    {
        private readonly IRefRepository _iRefRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly ILogger<RefService> _logger;

        public RefService(IRefRepository iRefRepository, ILogger<RefService> logger, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _iRefRepository = iRefRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public async Task<List<RefModel>> GetPriorities(Guid guid, RefRequest payload)
        {
            return await _iRefRepository.GetPriorities(guid, payload);
        }

        public async Task<List<RefModel>> GetProjectStatus(Guid guid, RefRequest payload)
        {
            return await _iRefRepository.GetProjectStatus(guid, payload);
        }

        public async Task<List<RefModel>> GetTodoStatus(Guid guid, RefRequest payload)
        {
            return await _iRefRepository.GetTodoStatus(guid, payload);
        }

        public async Task<List<RefModel>> GetTodoType(Guid guid, RefRequest payload)
        {
            return await _iRefRepository.GetTodoType(guid, payload);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services;
using PM.API.Domain.Services.Communication.Response;
using PM.API.Infrastructure;
using PM.API.Resources;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PM.API.Controllers
{
    [Authorize] 
    [Route("File")]
    public class FileController : PMBaseController
    {
        private readonly IFileService _fileService; 
        private readonly ILogger<FileController> _logger;
        private readonly AppSettings _appSettings; 

        public FileController(IFileService fileService, ILogger<FileController> logger, IOptions<AppSettings> appSettings)
        {
            _fileService = fileService;
            _logger = logger; 
            _appSettings = appSettings.Value;
        } 
        [HttpPost("UploadImage")]
        public async Task<FileResponse> UploadImage(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), _appSettings.FileFolderPath);
            string fileName = await _fileService.UploadImage(file, path);
            if (!string.IsNullOrEmpty(fileName))
            {
                return new FileResponse(new FileResource
                {
                    FileName = fileName,
                    Url = string.Format("{0}://{1}{2}/{3}", Request.Scheme, Request.Host.Value, _appSettings.FileRequestUrl, fileName)
                }); ;
            }
            else
            {
                return new FileResponse("Cannot image upload!");
            }
        }
    }
}

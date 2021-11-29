using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Domain.Services
{
    public interface IFileService
    {
        Task<string> UploadImage(IFormFile file, string path);
    }
}

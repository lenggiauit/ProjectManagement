using Microsoft.AspNetCore.Http;
using PM.API.Domain.Helpers;
using PM.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.API.Services
{
    public class FileService : IFileService
    {
        private readonly IImageWriter _imageWriter;
        public FileService(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<string> UploadImage(IFormFile file, string path)
        {
            return await _imageWriter.UploadImage(file, path);
        }
    }
}


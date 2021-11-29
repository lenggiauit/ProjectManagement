using PM.API.Resources;

namespace PM.API.Domain.Services.Communication.Response
{
    public class FileResponse : BaseResponse<FileResource>
    {

        public FileResponse(FileResource fileInfo) : base(fileInfo)
        { }


        public FileResponse(string message) : base(message)
        { }
    }
}
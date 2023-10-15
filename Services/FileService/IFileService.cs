using CVLookup_WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CVLookup_WebAPI.Services.FileService
{
    public interface IFileService
    {
        public Task<string> UploadFile(IFormFile file, string uploadPath);
        public Task<FileDownload> DownloadFile(string filename);
    }
}

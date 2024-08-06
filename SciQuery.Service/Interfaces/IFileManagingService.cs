using Microsoft.AspNetCore.Http;
using SciQuery.Service.DTOs.User;

namespace SciQuery.Service.Interfaces;

public interface IFileManagingService
{
    Task<string> UploadFileAsync(IFormFile file);
    Task<UserFiles> DownloadFileAsync(string path);
}

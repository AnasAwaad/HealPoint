using Microsoft.AspNetCore.Http;

namespace HealPoint.BusinessLogic.Contracts;
public interface IFileStorageService
{
    Task<string?> UploadFileAsync(IFormFile file, string folderName);
    void DeleteFile(string? filePath);
}

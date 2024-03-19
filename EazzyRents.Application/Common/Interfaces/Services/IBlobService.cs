using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.Common.Interfaces.Services
{
    public interface IBlobService
    {
        Task UploadBlobFileAsync(IFormFile formFile, string filePath, string guid = null);
        string GetBlobUrl(string filePath, string fileName);
        Task DeleteBlobFileAsync(string filePath, string fileName);
        Task<List<string>> ListBlobFilesAsync();
    }
}

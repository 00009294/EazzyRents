using EazzyRents.Core.Models;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IImageRepository
    {
        ImageData UploadImage(IFormFile files, string emailAddress);
        List<string> GetImages(string emailAddress);
        bool DeleteImages(string emailAddress);
        ImageData UpdateImage(IFormFile files, string emailAddress);
        ImageData UploadDefaultImage(string emailAddress, string imageUrl);
    }
}

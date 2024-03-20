using EazzyRents.Core.Models;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IImageRepository
    {
        void UploadImage(IFormFile files, string emailAddress);
        List<ImageData> GetImages(string emailAddress);
        bool DeleteImages(string emailAddress);
        bool UpdateImage(string emailAddress, ImageData imageData);
    }
}

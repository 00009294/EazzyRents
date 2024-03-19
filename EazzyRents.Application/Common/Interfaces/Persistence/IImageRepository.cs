using EazzyRents.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Services
{
    public interface IBlobService
    {
        Task UploadFileBlobAsync(IFormFile file, string filePath, string guid = null);
        string GetBlobUrl(string filePath, string fileName);
        Task DeleteFileBlobAsync(string filePath, string fileName);
    }
}

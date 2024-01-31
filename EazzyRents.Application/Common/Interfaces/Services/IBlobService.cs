using EazzyRents.Core.Models.BlobStorage;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Application.Common.Interfaces.Services
{
      public interface IBlobService
      {
            Task<string> UploadBlobFileAsync (IFormFile formFile);
            Task<BlobObject> GetBlobFile (string name);
            void DeleteBlobFileAsync (string name);
            Task<List<string>> ListBlobFilesAsync ();
      }
}

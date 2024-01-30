using EazzyRents.Core.Models.BlobStorage;

namespace EazzyRents.Application.Common.Interfaces.Services
{
      public interface IBlobService
      {
            Task<string> UploadBlobFileAsync (string fileName, string filePath);
            Task<BlobObject> GetBlobFile (string name);
            void DeleteBlobFileAsync (string name);
            Task<List<string>> ListBlobFilesAsync ();
      }
}

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Core.Models.BlobStorage;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Infrastructure.Services
{
      public class BlobService : IBlobService
      {
            private readonly BlobServiceClient blobServiceClient;
            private readonly IRealEstateRepository realEstateRepository;
            private readonly BlobContainerClient blobContainerClient;
            private static readonly List<string> imageExtensions = [" .JPG "," .JPEG "," .PNG "," .TXT "];

            public BlobService(
                  BlobServiceClient blobServiceClient,
                  IRealEstateRepository realEstateRepository)
            {
                  this.blobServiceClient = blobServiceClient;
                  this.realEstateRepository = realEstateRepository;
                  this.blobContainerClient = this.blobServiceClient.GetBlobContainerClient("blobcontainer");
            }

            public async Task UploadBlobFileAsync(
                        IFormFile file, 
                        string filePath, 
                        string guid = null)
            {
                  string fileName =
                        guid != null
                        ? $"{Path.GetFileNameWithoutExtension(file.FileName)}_{guid}{Path.GetExtension(file.FileName)}"
                        : file.FileName;

                  var blobClient = this.blobContainerClient.GetBlobClient($"{filePath}/{fileName}");

                  if(await blobClient.ExistsAsync())
                  {
                        throw new InvalidOperationException(
                                  $"File '{fileName}' already exists in the specified path."
                        );
                  }

                  var blobUploadOptions = new BlobUploadOptions
                  {
                        HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                  };

                  await blobClient.UploadAsync(file.OpenReadStream(), blobUploadOptions);

            }

            public string GetBlobUrl(string filePath, string fileName)
            {
                  var blobClient = this.blobContainerClient.GetBlobClient($"{filePath}/{fileName}");

                  var url = blobClient.Uri.AbsoluteUri;

                  return url;
            }

            public async Task DeleteBlobFileAsync(string filePath, string fileName)
            {
                  var blobClient = this.blobContainerClient.GetBlobClient($"{filePath}/{fileName}");
                  
                  await blobClient.DeleteIfExistsAsync();
            }

            public async Task<List<string>> ListBlobFilesAsync()
            {
                  List<string> bloblList = new List<string>();

                  await foreach(var blobItem in this.blobContainerClient.GetBlobsAsync())
                  {
                        bloblList.Add(blobItem.Name);
                  }

                  return bloblList;
            }
      }
}

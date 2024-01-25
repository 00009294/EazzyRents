using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Application.Common.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Infrastructure.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly AzureBlobStorageOptions azureBlobStorageOptions;

        public BlobService(BlobServiceClient blobServiceClient, IOptions<AzureBlobStorageOptions> azureBlobStorageOptions)
        {
            this.blobServiceClient = blobServiceClient;
            this.azureBlobStorageOptions = azureBlobStorageOptions.Value;
        }
        public async Task DeleteFileBlobAsync(string filePath, string fileName)
        {
            var containerClient = this.blobServiceClient.GetBlobContainerClient(
                this.azureBlobStorageOptions.ContainerName
            );

            var blobClient = containerClient.GetBlobClient($"{filePath}/{fileName}");

            await blobClient.DeleteIfExistsAsync();
        }

        public string GetBlobUrl(string filePath, string fileName)
        {
            var containerClient = this.blobServiceClient.GetBlobContainerClient(
                this.azureBlobStorageOptions.ContainerName
            );

            var blobClient = containerClient.GetBlobClient($"{filePath}/{fileName}");

            var url = blobClient.Uri.AbsoluteUri;

            return url;
        }

        public async Task UploadFileBlobAsync(IFormFile file,
            string filePath,
            string guid = null
        )
        {
            string fileName =
                guid != null
                    ? $"{Path.GetFileNameWithoutExtension(file.FileName)}_{guid}{Path.GetExtension(file.FileName)}"
                    : file.FileName;

            var containerClient = this.blobServiceClient.GetBlobContainerClient(
                this.azureBlobStorageOptions.ContainerName
            );

            var blobClient = containerClient.GetBlobClient($"{filePath}/{fileName}");

            if (await blobClient.ExistsAsync())
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
    }
}

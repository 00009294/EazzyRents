using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EazzyRents.Application.Common.Interfaces.Services;
using EazzyRents.Core.Models.BlobStorage;

namespace EazzyRents.Infrastructure.Services
{
      public class BlobService : IBlobService
      {
            private readonly BlobServiceClient blobServiceClient;
            private readonly BlobContainerClient blobContainerClient;
            private static readonly List<string> imageExtensions = [" .JPG ", " .JPEG ", " .PNG ", " .TXT "];

            public BlobService (BlobServiceClient blobServiceClient)
            {
                  this.blobServiceClient = blobServiceClient;
                  this.blobContainerClient = this.blobServiceClient.GetBlobContainerClient("blobcontainer");
            }

            public async Task<string> UploadBlobFileAsync (string fileName, string filePath)
            {
                  var blobClient = this.blobContainerClient.GetBlobClient(fileName);
                  var status = await blobClient.UploadAsync(filePath);

                  return blobClient.Uri.AbsoluteUri;
            }

            public async Task<BlobObject> GetBlobFile (string name)
            {
                  var fileName = new Uri(name).Segments.LastOrDefault();

                  try
                  {
                        var blobClient = this.blobContainerClient.GetBlobClient(name);
                        if (await blobClient.ExistsAsync())
                        {
                              BlobDownloadResult content = await blobClient.DownloadContentAsync();
                              var downloadedData = content.Content.ToStream();

                              if (imageExtensions.Contains(Path.GetExtension(fileName.ToUpperInvariant())))
                              {
                                    var extension = Path.GetExtension(fileName);

                                    return new BlobObject { Content = downloadedData, ContentType = "image/" + extension.Remove(0, 1) };
                              }
                              else
                              {
                                    return new BlobObject { Content = downloadedData, ContentType = content.Details.ContentType };
                              }
                        }
                        else
                        {
                              return null;
                        }

                  }
                  catch (Exception ex)
                  {
                        throw;
                  }
            }

            public async void DeleteBlobFileAsync (string name)
            {
                  var fileName = new Uri(name).Segments.LastOrDefault();
                  var blobClient = this.blobContainerClient.GetBlobClient(fileName);
                  await blobClient.DeleteIfExistsAsync();
            }

            public async Task<List<string>> ListBlobFilesAsync ()
            {
                  List<string> bloblList = new List<string>();

                  await foreach (var blobItem in this.blobContainerClient.GetBlobsAsync())
                  {
                        bloblList.Add(blobItem.Name);
                  }

                  return bloblList;
            }
      }
}

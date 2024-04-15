using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;
using Microsoft.AspNetCore.Http;

namespace EazzyRents.Infrastructure.Persistence
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext appDbContext;

        public ImageRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public bool DeleteImages(string emailAddress)
        {

            string folderPath = $@"StaticFiles\{emailAddress}";
            var allImages = this.appDbContext.Images.FirstOrDefault(e => e.Url == folderPath);

            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                    this.appDbContext.Images.Remove(allImages);
                    this.appDbContext.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<string> GetImages(string emailAddress)
        {
            string folderPath = $@"StaticFiles\{emailAddress}";

            var allImages = this.appDbContext.Images.FirstOrDefault(e => e.Url == folderPath);

            if (allImages == null) return new List<string>();

            List<string> allUrls = new List<string>();
            try
            {
                if (Directory.Exists(allImages.Url))
                {
                    string[] imageFiles = Directory.GetFiles(allImages.Url);
                    foreach (var imagePath in imageFiles)
                    {
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        string fileName = Path.GetFileName(imagePath);

                        allUrls.Add(folderPath + "/" + fileName);
                    }
                }

                return allUrls;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ImageData UpdateImage(IFormFile file, string emailAddress)
        {
            try
            {
                DeleteImages(emailAddress);
                string fileName = file.FileName;
                byte[] fileContent;

                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    fileContent = memoryStream.ToArray();
                }

                string folderPath = $@"StaticFiles\{emailAddress}";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, fileName);

                var imageData = this.appDbContext.Images.FirstOrDefault(img => img.FileName == fileName && img.Url == folderPath);

                if (imageData != null)
                {
                    imageData.Data = fileContent;
                    File.WriteAllBytes(filePath, fileContent);
                }

                imageData = new ImageData()
                {
                    FileName = fileName,
                    Url = folderPath,
                    Data = fileContent
                };

                this.appDbContext.Images.Add(imageData);
                this.appDbContext.SaveChanges();


                return imageData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ImageData UploadImage(IFormFile file, string emailAddress)
        {
            try
            {
                string fileName = file.FileName;
                byte[] fileContent;

                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    fileContent = memoryStream.ToArray();
                }


                string folderPath = $@"StaticFiles\{emailAddress}";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                ImageData formFile = new ImageData()
                {
                    FileName = fileName,
                    Url = folderPath,
                    Data = fileContent
                };

                string filePath = Path.Combine(folderPath, formFile.FileName);
                File.WriteAllBytes(filePath, formFile.Data);

                this.appDbContext.Images.Add(formFile);
                this.appDbContext.SaveChanges();

                return formFile;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

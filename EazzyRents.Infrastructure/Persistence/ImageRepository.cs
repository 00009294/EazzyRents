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

            string folderPath = $@"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles\{emailAddress}";
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
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
            //string folderPath = $@"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles\{emailAddress}";

            var allImages = this.appDbContext.Images.FirstOrDefault(e=>e.Url == emailAddress);

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

                        allUrls.Add(fileName+"/"+emailAddress);
                    }
                }

                return allUrls;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateImage(string emailAddress, ImageData imageData)
        {
            string folderPath = $@"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles\{emailAddress}";
            string imagePath = Path.Combine(folderPath, imageData.FileName);
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    return false;
                }

                File.WriteAllBytes(imagePath, imageData.Data);

                return true;
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


                string folderPath = $@"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles\{emailAddress}";

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

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
                return UploadImage(file, emailAddress);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ImageData UploadDefaultImage(string emailAddress, string imageUrl)
        {
            string filePath = @"C:\Users\fayzu\OneDrive\Рабочий стол\Images\img5.jpg";

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // Handle the case where the file does not exist
                throw new FileNotFoundException("File not found.", filePath);
            }

            byte[] imageContent = File.ReadAllBytes(filePath);

            string fileName = Path.GetFileName(filePath);

            IFormFile file = CreateFormFile(imageContent, fileName);


            //byte[] imageContent = File.ReadAllBytes(imageUrl);

            //IFormFile file = CreateFormFile(imageContent, imageUrl);
            //IFormFile file = null;

            //string fileName = file.FileName;
            byte[] fileContent;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream); // System.NullReferenceException: 'Object reference not set to an instance of an object.'
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

            string selectedfilePath = Path.Combine(folderPath, formFile.FileName);
            File.WriteAllBytes(selectedfilePath, formFile.Data);

            this.appDbContext.Images.Add(formFile);
            this.appDbContext.SaveChanges();

            return formFile;

        }
        private IFormFile CreateFormFile(byte[] fileContent, string fileName)
        {
            MemoryStream ms = new MemoryStream(fileContent);
            return new Microsoft.AspNetCore.Http.Internal.FormFile(ms, 0, fileContent.Length, "file", fileName);
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

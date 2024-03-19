using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Application.Helper;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<ImageData> GetImages(string emailAddress)
        {
            string folderPath = $@"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles\{emailAddress}";
            List<ImageData> images = new List<ImageData>(); 
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] imageFiles = Directory.GetFiles(folderPath);
                    foreach(var imagePath in imageFiles)
                    {
                        byte[] imageBytes = File.ReadAllBytes(imagePath);
                        string fileName =Path.GetFileName(imagePath);

                        images.Add(new ImageData
                        {
                            FileName = fileName,
                            Data = imageBytes
                        });
                    }
                }

                return images;
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
            catch(Exception ex)
            {
                throw;
            }
        }

        public void UploadImage(IFormFile file, string emailAddress)
        {
            try
            {
                string fileName = file.FileName;
                byte[] fileContent;
                
                using(var memoryStream =  new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
                
                ImageData formFile = new ImageData()
                {
                    FileName = fileName,
                    Data = fileContent
                };

                string folderPath = $@"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles\{emailAddress}"; // Replace this with the folder path

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, formFile.FileName);
                File.WriteAllBytes(filePath, formFile.Data);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

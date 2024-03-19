using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _imagesFolder = @"C:\Users\fayzu\projects\EazzyRents\EazzyRents.API\StaticFiles"; // Update with your actual folder path

        [HttpGet("{id}")]
        public IActionResult GetImages(string emailAddress)
        {
            string folderPath = Path.Combine(_imagesFolder, emailAddress);

            try
            {
                // Check if the folder exists
                if (!Directory.Exists(folderPath))
                {
                    return NotFound($"Folder for '{emailAddress}' not found.");
                }

                // Get all image files in the folder
                string[] imageFiles = Directory.GetFiles(folderPath);

                // Create a list to store image data DTOs
                List<ImageDto> imageDtos = new List<ImageDto>();

                foreach (string file in imageFiles)
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(file);
                    string base64String = Convert.ToBase64String(fileBytes);

                    imageDtos.Add(new ImageDto
                    {
                        FileName = Path.GetFileName(file),
                        Base64Data = base64String
                    });
                }

                // Return the list of image data DTOs
                return Ok(imageDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{fl}")]
        public IActionResult GetImage(string emailAddress, string fileName)
        {
            string imagePath = Path.Combine(_imagesFolder, emailAddress, fileName);

            try
            {
                // Check if the file exists
                if (!System.IO.File.Exists(imagePath))
                {
                    return NotFound(); // Return 404 Not Found if the image file is not found
                }

                // Read the image file as a byte array
                byte[] fileBytes = System.IO.File.ReadAllBytes(imagePath);

                // Determine the content type based on the file extension (e.g., image/jpeg for .jpg files)
                string contentType = GetContentType(fileName); // Adjust as needed based on the image file type

                // Set the Content-Disposition header to make the image downloadable
                string contentDisposition = $"attachment; filename=\"{fileName}\"";

                // Return the file content with appropriate headers
                return File(fileBytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private string GetContentType(string fileName)
        {
            // Determine content type based on file extension
            if (fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return "image/jpeg";
            }
            else if (fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
            {
                return "image/png";
            }
            else if (fileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
            {
                return "image/gif";
            }
            else
            {
                // Default content type for other file types
                return "application/octet-stream";
            }
        }
    }

    public class ImageDto
    {
        public string FileName { get; set; }
        public string Base64Data { get; set; }
    }
}


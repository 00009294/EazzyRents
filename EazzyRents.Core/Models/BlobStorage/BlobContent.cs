using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EazzyRents.Core.Models.BlobStorage
{
    public class BlobContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}

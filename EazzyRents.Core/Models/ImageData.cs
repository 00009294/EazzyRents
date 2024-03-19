using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Core.Models
{
    public class ImageData
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string EmailAddress { get; set; }
    }
}

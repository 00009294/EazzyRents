using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Helper.Dtos
{
    public class FileDto
    {
        public int Id { get; set; }

        public int RealEstateId { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }
    }
}

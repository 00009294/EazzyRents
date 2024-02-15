using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Core.Models
{
      public class File
      {
            public int Id { get; set; }
            public int RealEstateId { get; set; }
            public virtual RealEstate RealEstate { get; set; }
            public string FileName { get; set; }
            public string Path { get; set; }
      }
}

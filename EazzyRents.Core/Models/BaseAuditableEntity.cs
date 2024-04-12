using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Core.Models
{
    public class BaseAuditableEntity
    {
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}

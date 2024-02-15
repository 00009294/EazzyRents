using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
      public interface IFileRepository
      {
            Core.Models.File Add(Core.Models.File file);
      }
}

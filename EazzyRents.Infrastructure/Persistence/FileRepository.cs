using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Infrastructure.Persistence
{
      public class FileRepository : IFileRepository
      {
            private readonly AppDbContext appDbContext;

            public FileRepository(AppDbContext appDbContext)
            {
                  this.appDbContext = appDbContext;
            }

            public Core.Models.File Add(Core.Models.File file)
            {
                  this.appDbContext.Files.Add(file);
                  this.appDbContext.SaveChanges();
                  
                  return file;
            }
      }
}

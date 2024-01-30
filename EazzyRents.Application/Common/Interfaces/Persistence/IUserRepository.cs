using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
      public interface IUserRepository
      {
            void AddUser (User user);
            User? GetUserByEmail (string email);
      }
}

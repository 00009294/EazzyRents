using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Authentication
{
      public interface IJwtTokenGenerator
      {
            string GenerateToken (User user);
      }
}

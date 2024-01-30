using EazzyRents.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace EazzyRents.Core.Models
{
      public class User : IdentityUser
      {
            public UserRole UserRole { get; set; }
      }
}

using EazzyRents.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenParser
    {
        public (string username, string email, UserRole userRole) ParseToken(string token);
    }
}

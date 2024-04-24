using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Core.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Infrastructure.Authentication
{
    public class JwtTokenParser : IJwtTokenParser
    {
        public (string username, string email, UserRole userRole) ParseToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            var usernameClaim = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.GivenName)?.Value;
            var emailClaim = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;
            var userRoleClaim = token.Claims.FirstOrDefault(c => c.Type == "UserRole")?.Value;

            if (!Enum.TryParse(userRoleClaim, out UserRole userRole))
            {
                throw new ArgumentException("Invalid user role claim in token.");
            }

            return (usernameClaim, emailClaim, userRole);
        }
    }
}

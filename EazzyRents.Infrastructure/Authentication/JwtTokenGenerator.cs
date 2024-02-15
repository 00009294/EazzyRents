using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EazzyRents.Infrastructure.Authentication
{
      public class JwtTokenGenerator : IJwtTokenGenerator
      {
            private readonly IConfiguration configuration;

            public JwtTokenGenerator(IConfiguration configuration)
            {
                  this.configuration = configuration;
            }
            public string GenerateToken(User user)
            {
                  var signingCredentials = new SigningCredentials(
                      new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                          this.configuration["JWT:SigningKey"])),
                              SecurityAlgorithms.HmacSha512Signature);

                  var claims = new[]
                  {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim("UserRole", user.UserRole.ToString()),
            };

                  var securityToken = new SecurityTokenDescriptor
                  {

                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddDays(2),
                        SigningCredentials = signingCredentials,
                        Issuer = this.configuration["JWT:Issuer"],
                        Audience = this.configuration["JWT:Audience"]
                  };

                  var tokenHandler = new JwtSecurityTokenHandler();
                  var token = tokenHandler.CreateToken(securityToken);

                  return tokenHandler.WriteToken(token);

            }
      }
}

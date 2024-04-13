using EazzyRents.Application.Authentication.Common;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;
using System.Text.Encodings.Web;

namespace EazzyRents.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResultForRegistration>
    {
        private readonly UserManager<User> userManager;
        public RegisterCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AuthResultForRegistration> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return new AuthResultForRegistration { Message = "Null user" };
                }

                if(request.Password != request.ConfirmPassword)
                {
                    return new AuthResultForRegistration { Message = "Passwords are not identical" };
                }

                User user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    UserRole = request.UserRole
                };

                var createdUser = await this.userManager.CreateAsync(user, request.Password);
                var roleResult = await this.userManager.AddToRoleAsync(user, request.UserRole.ToString());

                if (createdUser.Succeeded)
                {
                    //await SendConfirmationEmail(createdUser, roleResult);
                }
                return new AuthResultForRegistration
                {
                    IsRegistered = true,
                    Message = "Successfully registered"
                };
            }
            catch
            {
                return new AuthResultForRegistration
                {
                    IsRegistered = false,
                    Message = "Error occured while registering user"
                };
            }
        }

    }
}

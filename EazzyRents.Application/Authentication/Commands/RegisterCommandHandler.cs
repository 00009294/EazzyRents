using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EazzyRents.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResultForRegistration>
    {
        private readonly UserManager<User> userManager;
        private readonly IUserRepository userRepository;
        public RegisterCommandHandler(UserManager<User> userManager, IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public async Task<AuthResultForRegistration> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return new AuthResultForRegistration { Message = "Null user" };
                }

                if (request.Password != request.ConfirmPassword)
                {
                    return new AuthResultForRegistration { Message = "Passwords are not identical" };
                }

                var userEmail = this.userRepository.GetUserByEmail(request.Email);

                if (userEmail != null)
                {
                    return new AuthResultForRegistration { Message = "This email is already used" };
                }

                var userName = this.userRepository.GetUserByUsername(request.UserName);

                if (userName != null)
                {
                    return new AuthResultForRegistration { Message = "This username is already taken" };
                }

                User user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    UserRole = request.UserRole
                };

                var createdUser = await this.userManager.CreateAsync(user, request.Password);
                var roleResult = await this.userManager.AddToRoleAsync(user, request.UserRole.ToString());

                if (!createdUser.Succeeded)
                {
                    return new AuthResultForRegistration
                    {
                        IsRegistered = false,
                        Message = "Error occured while registering user, please re-write all credentials again"
                    };
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

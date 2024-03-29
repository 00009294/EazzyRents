﻿using EazzyRents.Application.Authentication.Common;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

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
                User user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    UserRole = request.UserRole
                };

                var createdUSer = await this.userManager.CreateAsync(user, request.Password);
                var roleResult = await this.userManager.AddToRoleAsync(user, request.UserRole.ToString());
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

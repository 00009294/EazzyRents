using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.IO.Pipes;

namespace EazzyRents.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResultForRegistration>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, 
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }
        public Task<AuthResultForRegistration> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                UserRole = request.UserRole
            };

            //var password = this.passwordHasher.HashPassword(user, request.Password);
            //user.Password = password;

            var token = this.jwtTokenGenerator.GenerateToken(user);
            this.userRepository.AddUser(user);
            
            if(token != null)
            {
                return Task.FromResult(new AuthResultForRegistration(IsRegistered: true, Message: "Registered successfully"));
                
            }
            return Task.FromResult(new AuthResultForRegistration(IsRegistered: false, Message: "Registered successfully"));
             
        }

    }
}

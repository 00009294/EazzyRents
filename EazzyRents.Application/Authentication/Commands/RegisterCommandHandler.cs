using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResultForRegistration>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;


        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository
            )
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;

        }
        public Task<AuthResultForRegistration> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserRole = request.UserRole
            };
            var userEmail = this.userRepository.GetUserByEmail(request.Email);
            if (userEmail != null)
            {
                throw new Exception("Already registered user email");
            }
            user.Email = request.Email;
            user.Password = EnCryption.EnCrypt(request.Password);
            var token = this.jwtTokenGenerator.GenerateToken(user);
            this.userRepository.AddUser(user);

            if (token != null)
            {
                return Task.FromResult(new AuthResultForRegistration(IsRegistered: true, Message: "Registered successfully"));

            }
            return Task.FromResult(new AuthResultForRegistration(IsRegistered: false, Message: "Registered successfully"));

        }



    }
}

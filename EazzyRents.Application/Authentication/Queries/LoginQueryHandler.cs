using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using ErrorOr;
using MediatR;

namespace EazzyRents.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (this.userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new Exception("Invalid credentials");
            }

            if (user.Password != request.Password)
            {
                throw new Exception("Invalid password");
            }

            var token = this.jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }
    }
}

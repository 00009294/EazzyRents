using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Users.Queries
{
    public class GetByJwtTokenQueryHandler : IRequestHandler<GetByJwtTokenQuery, User>
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenParser jwtTokenParser;

        public GetByJwtTokenQueryHandler(
            IUserRepository userRepository,
            IJwtTokenParser jwtTokenParser)
        {
            this.userRepository = userRepository;
            this.jwtTokenParser = jwtTokenParser;
        }
        public Task<User> Handle(GetByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            var userCredentials = this.jwtTokenParser.ParseToken(request.jwtToken);
            User user = new User()
            {
                UserName = userCredentials.username,
                Email = userCredentials.email,
                UserRole = userCredentials.userRole
            };

            var selectedUser = this.userRepository.GetUserByUsername(user.UserName);
            if(selectedUser != null)
            {
                return Task.FromResult(user);
            }

            return Task.FromResult(new User());
        }
    }
}

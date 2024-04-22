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
    public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, User?>
    {
        private readonly IUserRepository userRepository;

        public GetByUserNameQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User?> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.userRepository.GetUserByUsername(request.userName));
        }
    }
}

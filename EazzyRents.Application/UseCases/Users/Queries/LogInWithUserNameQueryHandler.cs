using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Users.Queries
{
    public class LogInWithUserNameQueryHandler : IRequestHandler<LogInWithUserNameQuery, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        public LogInWithUserNameQueryHandler(IUserRepository userRepository, 
            UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }
        public Task<bool> Handle(LogInWithUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = this.userRepository.GetUserByUsername(request.username);
            
            if(user == null)
            {
                return Task.FromResult(false);
            }

            var isExist = this.userManager.CheckPasswordAsync(user, request.password);

            return isExist;
        }

    }
}

using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Authentication.Commands
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly SignInManager<User> signInManager;

        public LogoutCommandHandler(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await this.signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}

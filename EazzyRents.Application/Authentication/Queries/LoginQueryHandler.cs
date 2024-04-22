using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Common.Interfaces.Authentication;
using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EazzyRents.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResultForLogin>
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,
                UserManager<User> userManager,
                    SignInManager<User> signInManager)
        {
            this.jwtTokenGenerator = jwtTokenGenerator; 
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<AuthResultForLogin> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.Username.ToLower());
            if (user == null)
            {
                return new AuthResultForLogin()
                {
                    Message = "Unauthorized user"
                };
            }

            var signInUser = await this.signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
            if (signInUser != null)
            {
                return new AuthResultForLogin()
                {
                    IsRegistered = true,
                    Message = "Welcome",
                    Token = this.jwtTokenGenerator.GenerateToken(user)
                };
            }
            else
                return new AuthResultForLogin() { Message = "Wrong password or username" };
        }
    }
}

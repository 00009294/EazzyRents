using EazzyRents.Application.Authentication.Commands;
using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<AuthResultForRegistration> Register([FromQuery] RegisterCommand command)
        {
            var user = new RegisterCommand(command.UserName, command.Email, command.Password, command.ConfirmPassword, command.UserRole);
            return await this.mediator.Send(user);
        }

        [HttpPost("login")]
        public async Task<AuthResultForLogin> Login([FromQuery] LoginQuery query)
        {
            var user = new LoginQuery(query.Username, query.Password);
            return await this.mediator.Send(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(await this.mediator.Send(new LogoutCommand()));
        }

    }
}

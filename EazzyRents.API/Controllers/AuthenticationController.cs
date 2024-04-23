using EazzyRents.Application.Authentication.Commands;
using EazzyRents.Application.Authentication.Common;
using EazzyRents.Application.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("signup")]
        public async Task<AuthResultForRegistration> SignUp([FromBody] RegisterCommand command)
        {
            var user = new RegisterCommand(command.UserName, command.Email, command.Password, command.ConfirmPassword, command.UserRole);
            return await this.mediator.Send(user);
        }

        [HttpPost("signin")]
        public async Task<AuthResultForLogin> SignIn([FromBody] LoginQuery query)
        {
            var user = new LoginQuery(query.userName, query.password);
            return await this.mediator.Send(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(await this.mediator.Send(new LogoutCommand()));
        }

    }
}

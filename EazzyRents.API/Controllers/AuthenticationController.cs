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

        [HttpPost("register")]
        public async Task<AuthResultForRegistration> Register([FromBody] RegisterCommand command)
        {
            var user = new RegisterCommand(command.FirstName, command.LastName, command.PhoneNumber, command.Email, command.Password, command.UserRole);
            return await this.mediator.Send(user);
        }

        [HttpPost("login")]
        public async Task<AuthResultForLogin> Login([FromBody] LoginQuery query)
        {
            var user = new LoginQuery(query.Email, query.Password);
            return await this.mediator.Send(user);
        }
    }
}

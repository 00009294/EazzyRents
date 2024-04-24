using EazzyRents.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await this.mediator.Send(new GetByEmailQuery(email)));
        }

        [HttpGet]
        [Route("GetByUserName/{username}")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            return Ok(await this.mediator.Send(new GetByUserNameQuery(username)));
        }

        [HttpGet]
        [Route("GetByToken/")]
        public async Task<IActionResult> GetByToken(string token)
        {
            return Ok(await this.mediator.Send(new GetByJwtTokenQuery(token)));
        }
    }
}

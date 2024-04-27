using EazzyRents.Application.UseCases.Chats.Commands;
using EazzyRents.Application.UseCases.Chats.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator mediator;

        public ChatController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int roomId) 
        {
            return Ok(await this.mediator.Send(new GetAllMessagesQuery(roomId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateMessageCommand command)
        {
            return Ok(await this.mediator.Send(command));
        }
    }
}

using EazzyRents.Application.UseCases.Requests.Landlord.Commands;
using EazzyRents.Application.UseCases.Requests.Landlord.Queries;
using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public LandlordRequestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.mediator.Send(new GetAllQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromQuery] int requestId, [FromQuery] RequestStatus requestStatus)
        {
            var result = await this.mediator.Send(new UpdateRequestStatusCommand(requestId, requestStatus));

            return Ok(result);
        }
    }
}

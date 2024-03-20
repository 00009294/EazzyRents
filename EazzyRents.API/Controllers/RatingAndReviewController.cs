using EazzyRents.Application.UseCases.RatingsAndReviews.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingAndReviewController : ControllerBase
    {
        private readonly IMediator mediator;

        public RatingAndReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCommand createCommand)
        {
            return Ok(await this.mediator.Send(createCommand));
        }

    }
}

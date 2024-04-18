using EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Commands;
using EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateRatingAndReviewController : ControllerBase
    {
        private readonly IMediator mediator;

        public RealEstateRatingAndReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommand createCommand)
        {
            return Ok(await this.mediator.Send(createCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewsById(int id)
        {
            return Ok(await this.mediator.Send(new GetByIdQuery(id)));
        }
    }
}

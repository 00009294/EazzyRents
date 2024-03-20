using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.Users.Commands
{
    public record CreateCommand(RatingAndReview ratingAndReview) : IRequest<bool>;

}

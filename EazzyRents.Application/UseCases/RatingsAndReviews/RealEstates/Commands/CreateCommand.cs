using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Commands
{
    public record CreateCommand(RealEstateRatingAndReview realEstateRatingAndReview) : IRequest<bool>;
}

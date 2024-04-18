using EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Entities;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Queries
{
    public record GetByIdQuery(int realEstateId) : IRequest<List<RatingAndReviewEntity>>;
}

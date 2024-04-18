using MediatR;

namespace EazzyRents.Application.UseCases.RatingsAndReviews.RealEstates.Commands
{
    public class CreateCommand: IRequest<bool>
    {   
        public string SenderId { get; set; }
        public string ReviewMessage { get; set; }
        public int RealEstateId { get; set; }
        public int Rating {  get; set; }
    
    }
}

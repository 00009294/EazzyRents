using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Landlord.Queries
{
    public class GetAllByRequestStatusQueryHandler : IRequestHandler<GetAllByRequestStatusQuery, List<Request>>
    {
        private readonly IRequestRepository requestRepository;

        public GetAllByRequestStatusQueryHandler(
            IRequestRepository requestRepository
            )
        {
            this.requestRepository = requestRepository;
        }
        public Task<List<Request>> Handle(GetAllByRequestStatusQuery request, CancellationToken cancellationToken)
        {
            var landlord = this.requestRepository.GetAll().FirstOrDefault(u => u.Id == request.landlordId);

            if (landlord != null)
            {
                List<Request> selectedRequests = this.requestRepository.GetAll()
                    .Where(r => r.RequestStatus == request.requestStatus
                    && r.LandlordId == landlord.Id).ToList();

                return Task.FromResult(selectedRequests);
            }

            return Task.FromResult(new List<Request>());


        }
    }
}

using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Landlord.Queries
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<Request>>
    {
        private readonly IRequestRepository requestRepository;
        private readonly IUserRepository userRepository;

        public GetAllQueryHandler(
            IRequestRepository requestRepository,
            IUserRepository userRepository)
        {
            this.requestRepository = requestRepository;
            this.userRepository = userRepository;
        }
        public Task<List<Request>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var landlord = this.userRepository.GetUserById(request.LandlordId.ToString());

            if (landlord == null)
            {
                return Task.FromResult(new List<Request>());
            }

            List<Request> allRequests = this.requestRepository.GetAll().Where(u => u.Id.ToString() == landlord.Id).ToList();

            return Task.FromResult(allRequests);
        }
    }
}

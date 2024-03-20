using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Queries
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<Request>>
    {
        private readonly IRequestRepository requestRepository;

        public GetAllQueryHandler(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }
        public Task<List<Request>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(requestRepository.GetAll());
        }
    }
}

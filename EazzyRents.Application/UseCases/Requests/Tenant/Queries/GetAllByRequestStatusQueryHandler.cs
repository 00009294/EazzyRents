using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Queries
{
    public class GetAllByRequestStatusQueryHandler : IRequestHandler<GetAllByRequestStatusQuery, List<Request>>
    {
        private readonly IRequestRepository requestRepository;

        public GetAllByRequestStatusQueryHandler(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }
        public Task<List<Request>> Handle(GetAllByRequestStatusQuery request, CancellationToken cancellationToken)
        {

            var tenant = this.requestRepository.GetAll().FirstOrDefault(u => u.Id == request.tenantId);

            if (tenant != null)
            {
                List<Request> selectedRequests = this.requestRepository.GetAll()
                    .Where(r => r.RequestStatus == request.requestStatus
                    && r.TenantId == tenant.Id).ToList();

                return Task.FromResult(selectedRequests);
            }

            return Task.FromResult(new List<Request>());
        }
    }
}

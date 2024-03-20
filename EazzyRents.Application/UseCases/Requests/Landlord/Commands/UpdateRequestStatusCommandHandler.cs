using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Landlord.Commands
{
    public class UpdateRequestStatusCommandHandler : IRequestHandler<UpdateRequestStatusCommand, Request>
    {
        private readonly IRequestRepository requestRepository;

        public UpdateRequestStatusCommandHandler(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }
        public Task<Request> Handle(UpdateRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var selectedRequest = this.requestRepository.GetAll().FirstOrDefault(r => r.Id == request.RequestId);

            if (selectedRequest != null)
            {
                selectedRequest.RequestStatus = request.RequestStatus;

                return Task.FromResult(selectedRequest);
            }

            return Task.FromResult(new Request());
        }
    }
}

using EazzyRents.Application.Common.Interfaces.Persistence;
using MediatR;

namespace EazzyRents.Application.UseCases.Requests.Tenant.Commands
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IRequestRepository requestRepository;

        public DeleteCommandHandler(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }
        public Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(requestRepository.Delete(request.id));
        }
    }
}

using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Tenants.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, User>
    {
        private readonly IUserRepository userRepository;

        public GetByIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var tenant = this.userRepository.GetUserById(request.tenantId);

            if (tenant == null)
            {
                return Task.FromResult(new User());
            }

            return Task.FromResult(tenant);
        }
    }
}

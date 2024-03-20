using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;

namespace EazzyRents.Application.UseCases.Landlords.Queries
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
            var landlord = this.userRepository.GetUserById(request.landlordId);

            if (landlord == null)
            {
                return Task.FromResult(new User());
            }

            return Task.FromResult(landlord);
        }
    }
}

using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Enums;
using MediatR;

namespace EazzyRents.Application.UseCases.Hubs.Conversations.Commands
{
    public class CreateConversationCommandHandler : IRequestHandler<CreateConversationCommand, bool>
    {
        private readonly IConversationRepository conversationRepository;
        private readonly IUserRepository userRepository;

        public CreateConversationCommandHandler(IConversationRepository conversationRepository,
                IUserRepository userRepository)
        {
            this.conversationRepository = conversationRepository;
            this.userRepository = userRepository;
        }
        public Task<bool> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var tenantId = request.conversation.TenantId;
            var landlordId = request.conversation.LandlordId;

            var tenant = this.userRepository.GetUserById(tenantId.ToString());
            var landlord = this.userRepository.GetUserById(landlordId.ToString());

            if (tenant != null && landlord != null
                && tenant.UserRole != UserRole.Tenant
                && landlord.UserRole != UserRole.Landlord)
            {
                var result = this.conversationRepository.Add(request.conversation);

                return Task.FromResult(result);
            }

            return Task.FromResult(false);
        }
    }
}

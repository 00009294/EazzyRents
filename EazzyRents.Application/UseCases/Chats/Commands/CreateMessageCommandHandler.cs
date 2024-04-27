using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Chats.Commands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, bool>
    {
        private readonly IChatMessageRepository chatMessageRepository;

        public CreateMessageCommandHandler(IChatMessageRepository chatMessageRepository)
        {
            this.chatMessageRepository = chatMessageRepository;
        }
        public Task<bool> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                return Task.FromResult(false);
            }

            ChatMessage chatMessage = new ChatMessage()
            {
                Content = request.Content,
                UserRole = request.UserRole,
                RealEstateId = request.RealEstateId,
                Timestamp = DateTime.Now,
            };

            var res = this.chatMessageRepository.Add(chatMessage);

            return Task.FromResult(res);
        }
    }
}

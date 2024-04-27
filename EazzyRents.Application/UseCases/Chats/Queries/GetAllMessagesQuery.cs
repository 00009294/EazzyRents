using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.UseCases.Chats.Queries
{
    public record GetAllMessagesQuery(int roomId) : IRequest<List<ChatMessage>>;

    public class GetAllMessageQueryHandler : IRequestHandler<GetAllMessagesQuery, List<ChatMessage>>
    {
        private readonly IChatMessageRepository chatMessageRepository;

        public GetAllMessageQueryHandler(IChatMessageRepository chatMessageRepository)
        {
            this.chatMessageRepository = chatMessageRepository;
        }
        public Task<List<ChatMessage>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.chatMessageRepository.GetAll(request.roomId));
        }
    }
}

using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IChatMessageRepository
    {
        bool Add(ChatMessage chatMessage);
        List<ChatMessage> GetAll(int roomId);
    }
}

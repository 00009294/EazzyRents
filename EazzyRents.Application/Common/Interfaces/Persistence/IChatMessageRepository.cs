using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IChatMessageRepository
    {
        ChatMessage? GetById(int id);
        bool Add(ChatMessage chatMessage);
        bool Remove(ChatMessage chatMessage);
        bool Update(ChatMessage chatMessage);
        List<ChatMessage> GetAll(int chatMessageId);
    }
}

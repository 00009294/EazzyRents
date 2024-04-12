using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;

namespace EazzyRents.Infrastructure.Persistence
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly AppDbContext appDbContext;

        public ChatMessageRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool Add(ChatMessage chatMessage)
        {
            this.appDbContext.ChatMessages.Add(chatMessage);
            return this.appDbContext.SaveChanges() > 0;
        }

        public List<ChatMessage> GetAll(int chatMessageId)
        {
            return this.appDbContext.ChatMessages.Where(c => c.Id == chatMessageId).ToList();
        }

        public ChatMessage? GetById(int id)
        {
            return this.appDbContext.ChatMessages.FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(ChatMessage chatMessage)
        {
            if (chatMessage == null)
            {
                return false;
            }

            this.appDbContext.ChatMessages.Remove(chatMessage);

            return this.appDbContext.SaveChanges() > 0;
        }

        public bool Update(ChatMessage chatMessage)
        {
            if (chatMessage == null)
            {
                return false;
            }

            this.appDbContext.ChatMessages.Update(chatMessage);

            return this.appDbContext.SaveChanges() > 0;
        }
    }
}

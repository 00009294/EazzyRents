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

        public List<ChatMessage> GetAll(int roomId)
        {
            return this.appDbContext.ChatMessages.Where(m=>m.RealEstateId == roomId).ToList();
        }

    }
}

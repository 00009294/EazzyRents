using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Infrastructure.Persistence
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AppDbContext appDbContext;

        public ConversationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public bool Add(Conversation conversation)
        {
            this.appDbContext.Conversations.Add(conversation);
            return this.appDbContext.SaveChanges() > 0;
        }

        public List<Conversation> GetAll(int conversationId)
        {
            return this.appDbContext.Conversations.Where(c=>c.Id == conversationId).ToList(); 
        }

        public Conversation? GetById(int id)
        {
            if(id < 0)
            {
                return this.appDbContext.Conversations.FirstOrDefault(c => c.Id == id);
            }

            return new Conversation();
        }

        public bool Remove(Conversation conversation)
        {
            if(conversation == null)
            {
                return false;
            }

            this.appDbContext.Conversations.Remove(conversation);

            return this.appDbContext.SaveChanges() > 0;
        }

        public bool Update(Conversation conversation)
        {
            if (conversation != null)
            {
                this.appDbContext.Conversations.Update(conversation);
                
                return this.appDbContext.SaveChanges() > 0;
            }

            return false;
        }
    }
}

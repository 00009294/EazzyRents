using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IConversationRepository
    {
        Conversation? GetById(int id);
        bool Add(Conversation conversation);
        bool Remove(Conversation conversation);
        bool Update(Conversation conversation);
        List<Conversation> GetAll(int conversationId);
    }
}

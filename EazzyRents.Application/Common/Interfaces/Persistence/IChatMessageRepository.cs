using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

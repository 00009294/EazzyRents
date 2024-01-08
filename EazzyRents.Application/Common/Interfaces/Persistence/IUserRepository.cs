using EazzyRents.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUserByEmail(string email);
    }
}

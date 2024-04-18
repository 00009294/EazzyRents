using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void AddUser(User user);
        User? GetUserByEmail(string email);
        User? GetUserByUsername(string username);
        User? GetUserById(string id);
    }
}

using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void AddUser(User user);
        User? GetUserByEmail(string email);
        User? GetUserById(int id);
    }
}

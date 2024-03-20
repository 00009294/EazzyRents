using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;

namespace EazzyRents.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void AddUser(User user)
        {
            this.appDbContext.Users.Add(user);
            this.appDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return this.appDbContext.Users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return this.appDbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserById(int id)
        {
            return this.appDbContext.Users.FirstOrDefault(u => u.Id == id.ToString());
        }
    }
}

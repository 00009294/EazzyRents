using EazzyRents.Application.Common.Interfaces.Persistence;
using EazzyRents.Core.Models;
using EazzyRents.Infrastructure.Data;

namespace EazzyRents.Infrastructure.Persistence
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext appDbContext;

        public RequestRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Request Create(Request request)
        {
            this.appDbContext.Requests.Add(request);
            if (this.appDbContext.SaveChanges() > 0)
            {
                return request;
            }

            return new Request();
        }

        public bool Delete(int id)
        {
            var request = this.appDbContext.Requests.FirstOrDefault(r => r.Id == id);
            if (request != null)
            {
                this.appDbContext.Requests.Remove(request);
                return this.appDbContext.SaveChanges() > 0;
            }

            return false;
        }

        public List<Request> GetAll()
        {
            return this.appDbContext.Requests.ToList();
        }
    }
}

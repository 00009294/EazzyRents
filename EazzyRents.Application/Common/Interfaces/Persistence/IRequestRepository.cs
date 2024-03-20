using EazzyRents.Core.Models;

namespace EazzyRents.Application.Common.Interfaces.Persistence
{
    public interface IRequestRepository
    {
        Request Create(Request request);
        List<Request> GetAll();
        bool Delete(int id);
    }
}

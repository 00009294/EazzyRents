using EazzyRents.Application.Common.Interfaces.Services;

namespace EazzyRents.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimerProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

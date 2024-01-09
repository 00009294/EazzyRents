namespace EazzyRents.Application.Common.Interfaces.Services
{
    public interface IDateTimerProvider
    {
        DateTime UtcNow { get; }
    }
}

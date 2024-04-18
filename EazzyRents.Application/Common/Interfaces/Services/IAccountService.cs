namespace EazzyRents.Application.Common.Interfaces.Services
{
    public interface IAccountService
    {
        Task SendConfirmationEmail(string email, string subject, string message);
    }
}

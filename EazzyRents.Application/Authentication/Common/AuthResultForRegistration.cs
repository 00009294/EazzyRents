namespace EazzyRents.Application.Authentication.Common
{
    public record AuthResultForRegistration(
        bool IsRegistered,
        string Message
        );
}

using FluentValidation;

namespace EazzyRents.Application.Authentication.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(u => u.password).NotEmpty();
        }
    }
}

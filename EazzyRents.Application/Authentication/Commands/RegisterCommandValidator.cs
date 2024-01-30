using FluentValidation;

namespace EazzyRents.Application.Authentication.Commands
{
      public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
      {
            public RegisterCommandValidator ()
            {
                  RuleFor(u => u.Email).NotEmpty().EmailAddress();
                  RuleFor(u => u.Password).NotEmpty().MinimumLength(6);
            }
      }
}


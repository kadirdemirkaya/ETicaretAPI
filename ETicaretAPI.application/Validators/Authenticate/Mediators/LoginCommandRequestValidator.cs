using ETicaretAPI.application.Mediators.Commands.Authenticate.Login;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Authenticate.Mediators
{
    public class LoginCommandRequestValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandRequestValidator()
        {
            RuleFor(l => l.LoginDto).SetValidator(new LoginValidator());
        }
    }
}

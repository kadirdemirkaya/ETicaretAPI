using ETicaretAPI.application.Mediators.Commands.Authenticate.Register;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Authenticate.Mediators
{
    public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandRequestValidator()
        {
            RuleFor(l => l.RegisterDto).SetValidator(new RegisterValidator());
        }
    }
}

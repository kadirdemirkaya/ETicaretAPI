using ETicaretAPI.application.DTOs.Authenticate;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Authenticate
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty().WithMessage("Email is not empty").NotNull().WithMessage("Email is not null").Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").WithMessage("Invalid Email Format");

            RuleFor(l => l.Password).NotEmpty().WithMessage("Password is not empty").NotNull().WithMessage("Password is not null").Matches(@"^(?=.*\d)[a-zA-Z0-9]{3,}$").WithMessage("Password must contain at least 3 characters and at least 1 number");
        }
    }
}

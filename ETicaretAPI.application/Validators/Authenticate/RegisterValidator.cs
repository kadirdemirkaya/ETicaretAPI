using ETicaretAPI.application.DTOs.Authenticate;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Authenticate
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("FirstName Name is not empty").NotNull().WithMessage("FirstName Name is not null").MinimumLength(3).WithMessage("FirstName must be at least 3 character").MaximumLength(100).WithMessage("FirstName should not exceed 100 character");

            RuleFor(r => r.LastName).NotEmpty().WithMessage("LastName Name is not empty").NotNull().WithMessage("LastName Name is not null").MinimumLength(3).WithMessage("LastName must be at least 3 character").MaximumLength(100).WithMessage("LastName should not exceed 100 character");

            RuleFor(r => r.PhoneNumber).NotEmpty().WithMessage("PhoneNumber Name is not empty").NotNull().WithMessage("PhoneNumber Name is not null").Length(11).WithMessage("PhoneNumber must be 11 character");

            RuleFor(r => r.Email).NotEmpty().WithMessage("Email is not empty").NotNull().WithMessage("Email is not null").Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").WithMessage("Invalid Email Format");

            RuleFor(r => r.Password).NotEmpty().WithMessage("Password is not empty").NotNull().WithMessage("Password is not null").Matches(@"^(?=.*\d)[a-zA-Z0-9]{3,}$").WithMessage("Password must contain at least 3 characters and at least 1 number");

            RuleFor(r => r.Gender).NotEmpty().WithMessage("FirstName Name is not empty").NotNull().WithMessage("FirstName Name is not null");

            RuleFor(r => r.UserName).NotEmpty().WithMessage("UserName Name is not empty").NotNull().WithMessage("UserName Name is not null").MinimumLength(3).WithMessage("UserName must be at least 3 character").MaximumLength(100).WithMessage("UserName should not exceed 100 character");
        }
    }
}

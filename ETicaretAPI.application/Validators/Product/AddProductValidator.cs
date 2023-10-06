using ETicaretAPI.application.DTOs.Product;
using ETicaretAPI.domain.Entites;
using FluentValidation;

namespace ETicaretAPI.application.Validators
{
    public class AddProductValidator : AbstractValidator<AddProductDto>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product Name is not empty").NotNull().WithMessage("Product Name is not null").MinimumLength(2).WithMessage("Product name must be at least three character").MaximumLength(100).WithMessage("Product name should be no more hundred  character");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Product Price is not empty").NotNull().WithMessage("Product Price is not null").GreaterThanOrEqualTo(0).WithMessage("Product Price cannot be negative");

            RuleFor(p=>p.Stock).NotEmpty().WithMessage("Product Stock is not empty").NotNull().WithMessage("Product Stock is not null").GreaterThanOrEqualTo(0).WithMessage("Product Stock cannot be negative");
        }
    }
}

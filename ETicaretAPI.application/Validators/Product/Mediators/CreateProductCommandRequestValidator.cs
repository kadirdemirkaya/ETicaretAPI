using ETicaretAPI.application.Mediators.Commands.Product.CreateProduct;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Product.Mediators
{
    public class CreateProductCommandRequestValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandRequestValidator()
        {
            //AddProductValidator ayarları AddProductDto ya atandı
            RuleFor(request => request.AddProductDto).SetValidator(new AddProductValidator());
        }
    }
}

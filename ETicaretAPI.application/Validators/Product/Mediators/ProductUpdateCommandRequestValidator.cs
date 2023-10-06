using ETicaretAPI.application.Mediators.Commands.Product.ProductUpdate;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Product.Mediators
{
    public class ProductUpdateCommandRequestValidator : AbstractValidator<ProductUpdateCommandRequest>
    {
        public ProductUpdateCommandRequestValidator()
        {
            RuleFor(request => request.UpdateProductDto).SetValidator(new UpdateProductValidator());
        }
    }
}

using ETicaretAPI.application.Mediators.Commands.Product.ProductDelete;
using FluentValidation;

namespace ETicaretAPI.application.Validators.Product.Mediators
{
    public class ProductDeleteCommandRequestValidator : AbstractValidator<ProductDeleteCommandRequest>
    {
        public ProductDeleteCommandRequestValidator()
        {
            //RuleFor(request => request.DeleteProductDto).SetValidator(new DeleteProductValidator());
        }
    }
}

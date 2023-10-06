using ETicaretAPI.application.DTOs.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductDto>
    {
        public DeleteProductValidator()
        {
            //RuleFor(d => d.Id).NotEmpty().WithMessage("Id is not empty").NotNull().WithMessage("Id is not null");
        }
    }
}

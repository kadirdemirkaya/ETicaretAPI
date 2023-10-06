using ETicaretAPI.application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Mediators.Commands.Product.ProductUpdate
{
    public class ProductUpdateCommandRequest : IRequest<ProductUpdateCommandResponse>
    {
        public UpdateProductDto UpdateProductDto { get; set; }
    }
}

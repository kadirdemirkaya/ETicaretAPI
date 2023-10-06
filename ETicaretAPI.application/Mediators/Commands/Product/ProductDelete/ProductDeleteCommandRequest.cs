using ETicaretAPI.application.DTOs.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Mediators.Commands.Product.ProductDelete
{
    public class ProductDeleteCommandRequest : IRequest<ProductDeleteCommandResponse>
    {
        [FromHeader]
        public Guid Id { get; set; }
    }
}

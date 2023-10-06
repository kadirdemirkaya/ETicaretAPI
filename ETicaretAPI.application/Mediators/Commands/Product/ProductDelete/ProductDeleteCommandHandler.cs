using AutoMapper;
using ETicaretAPI.application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Mediators.Commands.Product.ProductDelete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommandRequest, ProductDeleteCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IMapper mapper;

        public ProductDeleteCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            this.productWriteRepository = productWriteRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDeleteCommandResponse> Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<ETicaretAPI.domain.Entites.Product>(request);
            bool result = productWriteRepository.Delete(map);
            await productWriteRepository.SaveChangesAsync();
            return new() { result = result };
        }
    }
}

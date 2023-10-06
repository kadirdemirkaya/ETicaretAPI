using AutoMapper;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.ProductUpdate
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest, ProductUpdateCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IMapper mapper;

        public ProductUpdateCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            this.productWriteRepository = productWriteRepository;
            this.mapper = mapper;
        }

        public async Task<ProductUpdateCommandResponse> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<ETicaretAPI.domain.Entites.Product>(request.UpdateProductDto);
            bool result = productWriteRepository.UpdateAsync(map);
            await productWriteRepository.SaveChangesAsync();
            return new() { result = result };
        }
    }
}

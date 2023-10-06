using AutoMapper;
using ETicaretAPI.application.DTOs.Product;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductIdWithCode
{
    public class GetProductWithCodeQueryHandler : IRequestHandler<GetProductWithCodeQueryRequest, GetProductWithCodeQueryResponse>
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IMapper mapper;

        public GetProductWithCodeQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            this.productReadRepository = productReadRepository;
            this.mapper = mapper;
        }

        public async Task<GetProductWithCodeQueryResponse> Handle(GetProductWithCodeQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await productReadRepository.GetAsync(x => x.ProductCode == request.ProductCode.ToString());
            var map = mapper.Map<GetProductWithCodeDto>(response);
            return new() { GetProductIdWithCodeDto = map };
        }
    }
}

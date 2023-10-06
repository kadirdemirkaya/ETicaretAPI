using AutoMapper;
using ETicaretAPI.application.DTOs.Product;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductByGuid
{
    public class GetProductByGuidQueryHandler : IRequestHandler<GetProductByGuidQueryRequest, GetProductByGuidQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductReadRepository _productReadRepository;
        public GetProductByGuidQueryHandler(IMapper mapper, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<GetProductByGuidQueryResponse> Handle(GetProductByGuidQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByGuidAsync(request.Id);
            var map = _mapper.Map<GetProductByGuidDto>(product);
            return new() { GetProductByGuidDto = map };
        }
    }
}

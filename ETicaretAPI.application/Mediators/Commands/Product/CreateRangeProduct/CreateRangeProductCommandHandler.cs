using AutoMapper;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.CreateRangeProduct
{
    public class CreateRangeProductCommandHandler : IRequestHandler<CreateRangeProductCommandRequest, CreateRangeProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductWriteRepository _productWriteRepository;

        public CreateRangeProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateRangeProductCommandResponse> Handle(CreateRangeProductCommandRequest request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<List<ETicaretAPI.domain.Entites.Product>>(request.AddProductDtos);
            var issuccess = await _productWriteRepository.AddRangeAsync(map);
            await _productWriteRepository.SaveChangesAsync();
            return new() { isSuccess = issuccess };
        }
    }
}

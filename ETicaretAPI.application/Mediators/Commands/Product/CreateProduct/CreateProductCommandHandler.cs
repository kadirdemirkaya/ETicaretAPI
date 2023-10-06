using AutoMapper;
using ETicaretAPI.application.Abstractions.Hubs;
using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IMapper mapper;
        private readonly IImageService imageService;
        private readonly IProductHubService productHubService;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, IImageService imageService, IProductHubService productHubService)
        {
            this.productWriteRepository = productWriteRepository;
            this.mapper = mapper;
            this.imageService = imageService;
            this.productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<ETicaretAPI.domain.Entites.Product>(request.AddProductDto);
            var result = await productWriteRepository.AddAsync(map);
            await productWriteRepository.SaveChangesAsync();

            await productHubService.ProductAddedMessageAsync($"{map.Name} Product Added Process Succesfully");

            return new() { message = result.ToString() };
        }
    }
}

using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.Repositories;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.DeleteProductImageByGuid
{
    public class DeleteProductImageByGuidCommandHandler : IRequestHandler<DeleteProductImageByGuidCommandRequest, DeleteProductImageByGuidCommandResponse>
    {
        private readonly IImageService imageService;
        private readonly IImageReadRepository imageReadRepository;
        public DeleteProductImageByGuidCommandHandler(IImageService imageService, IImageReadRepository imageReadRepository)
        {
            this.imageService = imageService;
            this.imageReadRepository = imageReadRepository;
        }

        public async Task<DeleteProductImageByGuidCommandResponse> Handle(DeleteProductImageByGuidCommandRequest request, CancellationToken cancellationToken)
        {
            var image = await imageReadRepository.GetAsync(x => x.Path == request.Path);
            bool response = await imageService.ProductPhotoDeleteAsync(image.Id);
            return new() { result = response };
        }
    }
}

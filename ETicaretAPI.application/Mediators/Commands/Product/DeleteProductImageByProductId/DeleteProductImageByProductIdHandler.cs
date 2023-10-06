using ETicaretAPI.application.Abstractions.Services;
using ETicaretAPI.application.UnitOfWorks;
using MediatR;

namespace ETicaretAPI.application.Mediators.Commands.Product.DeleteProductImageByProductId
{
    public class DeleteProductImageByProductIdHandler : IRequestHandler<DeleteProductImageByProductIdRequest, DeleteProductImageByProductIdResponse>
    {
        private readonly IImageService imageService;
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductImageByProductIdHandler(IImageService imageService, IUnitOfWork unitOfWork)
        {
            this.imageService = imageService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductImageByProductIdResponse> Handle(DeleteProductImageByProductIdRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<ETicaretAPI.domain.Entites.ImageProduct>().GetAllAsync(ip=>ip.ProductId == request.ProductId);
            if (product != null)
            {
                bool result = await imageService.ProductAndImagesDeleteAsync(request.ProductId);
                return new() { result = result };
            }
            return new() { result = false };
        }
    }
}

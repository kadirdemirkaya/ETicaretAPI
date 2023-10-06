using ETicaretAPI.application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.application.Mediators.Queries.Product.GetProductImageByProductId
{
    public class GetProductImageByProductIdHandler : IRequestHandler<GetProductImageByProductIdRequest, GetProductImageByProductIdResponse>
    {
        private readonly IImageService imageService;

        public GetProductImageByProductIdHandler(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<GetProductImageByProductIdResponse> Handle(GetProductImageByProductIdRequest request, CancellationToken cancellationToken)
        {
            var response = await imageService.GetProductImages(request.ProductId);
            return new() { Paths = response };
        }
    }
}

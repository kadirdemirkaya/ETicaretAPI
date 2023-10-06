using ETicaretAPI.application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.application.Mediators.Commands.Product.ProducAddPhoto
{
    public class ProducAddPhotoResponseCommandHandler : IRequestHandler<ProducAddPhotoResponseCommandRequest, ProducAddPhotoResponseCommandResponse>
    {
        private readonly IImageService imageService;

        public ProducAddPhotoResponseCommandHandler(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<ProducAddPhotoResponseCommandResponse> Handle(ProducAddPhotoResponseCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await imageService.ProductPhotosAddAsync(request.files, request.ProductId);
            return new() { result = response };
        }
    }
}

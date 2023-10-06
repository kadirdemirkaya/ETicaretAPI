using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.application.Mediators.Commands.Product.ProducAddPhoto
{
    public class ProducAddPhotoResponseCommandRequest : IRequest<ProducAddPhotoResponseCommandResponse>
    {
        public List<IFormFile>? files { get; set; }
        public Guid ProductId { get; set; }
    }
}

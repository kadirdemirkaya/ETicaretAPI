using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.application.Mediators.Commands.Product.DeleteProductImageByGuid
{
    public class DeleteProductImageByGuidCommandRequest : IRequest<DeleteProductImageByGuidCommandResponse>
    {
        [FromHeader]
        public string Path { get; set; }
    }
}

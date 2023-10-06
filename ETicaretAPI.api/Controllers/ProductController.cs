using ETicaretAPI.application.Mediators.Commands.Product.CreateProduct;
using ETicaretAPI.application.Mediators.Commands.Product.CreateRangeProduct;
using ETicaretAPI.application.Mediators.Commands.Product.DeleteProductImageByGuid;
using ETicaretAPI.application.Mediators.Commands.Product.DeleteProductImageByProductId;
using ETicaretAPI.application.Mediators.Commands.Product.ProducAddPhoto;
using ETicaretAPI.application.Mediators.Commands.Product.ProductDelete;
using ETicaretAPI.application.Mediators.Commands.Product.ProductUpdate;
using ETicaretAPI.application.Mediators.Queries.Product.GetAllProduct;
using ETicaretAPI.application.Mediators.Queries.Product.GetProductByGuid;
using ETicaretAPI.application.Mediators.Queries.Product.GetProductIdWithCode;
using ETicaretAPI.application.Mediators.Queries.Product.GetProductImageByProductId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ETicaretAPI.api.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse? response = await mediator.Send(createProductCommandRequest);
            return Ok(response);
        }

        [Route("AddRangeProductAsync")]
        [HttpPost]
        public async Task<IActionResult> AddRangeProductAsync([FromBody] CreateRangeProductCommandRequest createRangeProductCommandRequest)
        {
            CreateRangeProductCommandResponse response = await mediator.Send(createRangeProductCommandRequest);
            return Ok(response);
        }

        [Route("GetAllProduct")]
        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse? response = await mediator.Send(getAllProductQueryRequest);
            var json = JsonSerializer.Serialize(response);
            return Ok(json);
        }

        [Route("GetProductByGuid")]
        [HttpGet]
        public async Task<IActionResult> GetProductByGuid([FromHeader] GetProductByGuidQueryRequest getProductByGuidQueryRequest)
        {
            GetProductByGuidQueryResponse? response = await mediator.Send(getProductByGuidQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetProductWithCode")]
        public async Task<IActionResult> GetProductWithCode([FromHeader] GetProductWithCodeQueryRequest getProductWithCodeQueryRequest)
        {
            var response = await mediator.Send(getProductWithCodeQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("ProducAddPhoto")]
        public async Task<IActionResult> ProducAddPhoto([FromForm] ProducAddPhotoResponseCommandRequest addPhotoResponseCommandRequest)
        {
            ProducAddPhotoResponseCommandResponse response = await mediator.Send(addPhotoResponseCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("DeleteProductImageByGuid")]
        public async Task<IActionResult> DeleteProductImageByGuid([FromHeader] DeleteProductImageByGuidCommandRequest deleteProductImageByGuidCommandRequest)
        {
            DeleteProductImageByGuidCommandResponse response = await mediator.Send(deleteProductImageByGuidCommandRequest);
            if (response.result)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("DeleteProductImageByProductId")]
        public async Task<IActionResult> DeleteProductImageByProductId([FromHeader] DeleteProductImageByProductIdRequest deleteProductImageByProductIdRequest)
        {
            DeleteProductImageByProductIdResponse response = await mediator.Send(deleteProductImageByProductIdRequest);
            if (response.result)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Route("ProductUpdate")]
        public async Task<IActionResult> ProductUpdate([FromBody] ProductUpdateCommandRequest productUpdateCommandRequest)
        {
            ProductUpdateCommandResponse response = await mediator.Send(productUpdateCommandRequest);
            if (response.result)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("ProductDelete")]
        public async Task<IActionResult> ProductDelete([FromHeader] ProductDeleteCommandRequest productDeleteCommandRequest)
        {
            ProductDeleteCommandResponse response = await mediator.Send(productDeleteCommandRequest);
            if (response.result)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetProductImageByProductId")]
        public async Task<IActionResult> GetProductImageByProductId([FromHeader] GetProductImageByProductIdRequest getProductImageByProductIdRequest)
        {
            GetProductImageByProductIdResponse response = await mediator.Send(getProductImageByProductIdRequest);
            return Ok(response);
        }
    }
}
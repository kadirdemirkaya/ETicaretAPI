using ETicaretAPI.application.Mediators.Queries.Category.GetAllCategory;
using ETicaretAPI.application.Mediators.Queries.Category.ProductTotalOfCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory([FromQuery]GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response = await mediator.Send(getAllCategoryQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ProductTotalOfCategories")]
        public async Task<IActionResult> ProductTotalOfCategories([FromQuery]ProductTotalOfCategoriesRequest productTotalOfCategoriesRequest)
        {
            ProductTotalOfCategoriesResponse response = await mediator.Send(productTotalOfCategoriesRequest);
            return Ok(response);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Contracts;
using WebShop.Core.Models;

namespace WebShop.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;
		// Dependancy inversion of control - inject service
		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		//These Attributes below are for API description
		[Produces("application/json")]
		[ProducesResponseType(200,StatusCode=StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductModel>))]
		public async Task<IActionResult> GetAllProducts() 
		{
			return Ok(await productService.GetAllProducts());
		}
	}
}

using ETrade.Application.Repositories.ProductRepository;
using ETrade.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IProductWriteRepository _productWriteRepository;

		public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
		}

		[HttpGet]
		[Route("GetProducts")]
		public IActionResult GetAllProducts()
		{
			IQueryable<Product> products = _productReadRepository.GetAll();
			return Ok(products);
		}

		[HttpGet]
		[Route("[action]/{id}")]
		public async Task<IActionResult> GetProductById(string id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id);
			return Ok(product);
		}
	}
}

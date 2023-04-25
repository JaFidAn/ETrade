using ETrade.Application.Features.Commands.ProductCommands.CreateProduct;
using ETrade.Application.Features.Commands.ProductCommands.DeleteProduct;
using ETrade.Application.Features.Commands.ProductCommands.UpdateProduct;
using ETrade.Application.Features.Queries.ProductQueries.GetProduct;
using ETrade.Application.Features.Queries.ProductQueries.GetProducts;
using ETrade.Application.ViewModels.Products;
using ETrade.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETrade.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetProductsQueryRequest getProductsQueryRequest)
		{
			GetProductsQueryResponse response = await _mediator.Send(getProductsQueryRequest);
			return Ok(response);
		}

		[HttpGet("{Id}")]
		[Authorize(AuthenticationSchemes = "Admin")]
		public async Task<IActionResult> Get([FromRoute]GetProductByIdQueryRequest getProductByIdQueryRequest)
		{
			GetProductByIdQueryResponse response = await _mediator.Send(getProductByIdQueryRequest);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
		{
			CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
			return StatusCode((int)HttpStatusCode.Created);
		}

		[HttpPut]
		public async Task<IActionResult> EditProduct([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
		{
			UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
			return Ok(response);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
		{
			DeleteProductCommandResponse response = await _mediator.Send(deleteProductCommandRequest);
			return Ok(response);
		}
	}
}

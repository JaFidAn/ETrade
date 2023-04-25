using ETrade.Application.Repositories.ProductRepository;
using ETrade.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.ProductCommands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
	{
		private readonly IProductWriteRepository _productWriteRepository;
		private readonly IProductReadRepository _productReadRepository;

		public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
		{
			_productWriteRepository = productWriteRepository;
			_productReadRepository = productReadRepository;
		}

		public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productReadRepository.GetByIdAsync(request.Product_Update_VM.Id);
			product.Name = request.Product_Update_VM.Name;
			product.Stock = request.Product_Update_VM.Stock;
			product.Price = request.Product_Update_VM.Price;

			await _productWriteRepository.SaveAsync();
			return new UpdateProductCommandResponse()
			{
				Id = request.Product_Update_VM.Id,
				Name = product.Name,
				Stock = product.Stock,
				Price = product.Price,
			};
		}
	}
}

using ETrade.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.ProductCommands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
	{
		private readonly IProductWriteRepository _productWriteRepository;

		public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
		{
			_productWriteRepository = productWriteRepository;
		}

		public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			await _productWriteRepository.RemoveAsync(request.Id);
			await _productWriteRepository.SaveAsync();
			return new();
		}
	}
}

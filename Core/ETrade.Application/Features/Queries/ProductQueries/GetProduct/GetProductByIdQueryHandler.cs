using ETrade.Application.Repositories.ProductRepository;
using ETrade.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Queries.ProductQueries.GetProduct
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
	{
		private readonly IProductReadRepository _productReadRepository;

		public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
		{
			_productReadRepository = productReadRepository;
		}

		public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
		{
			Product product = await _productReadRepository.GetByIdAsync(request.Id);
			return new GetProductByIdQueryResponse()
			{
				Name = product.Name,
				Price = product.Price,
				Stock = product.Stock,
				CreatedDate = product.CreatedDate,
				UpdateddDate = product.UpdatedDate
			};
		}
	}
}

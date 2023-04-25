using ETrade.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Queries.ProductQueries.GetProducts
{
    public class GetProductsQueryRequest : IRequest<GetProductsQueryResponse>
    {
        public Pagination Pagination { get; set; } = new() { Page = 0, Size = 5 };
    }
}

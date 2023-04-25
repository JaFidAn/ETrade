using ETrade.Application.ViewModels.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Features.Commands.ProductCommands.UpdateProduct
{
	public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
	{
        public Product_Update_VM Product_Update_VM { get; set; }
    }
}

using ETrade.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Validations.FluentValidation.Products
{
	public class CreateProductValidator : AbstractValidator<Product_Create_VM>
	{
		public CreateProductValidator()
		{
			RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Please write Product Name")
				.MaximumLength(50).MinimumLength(3).WithMessage("Minimum Lengh of Name should be 3");
			RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Please write Stock quantity")
				.Must(s => s >= 0).WithMessage("Stock quantity can not be less than 0");
			RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Please write Price amount")
				.Must(p => p > 0).WithMessage("Price amount can not be less than 0");
		}
	}
}

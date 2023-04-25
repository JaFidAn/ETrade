using ETrade.Application.Repositories.CustomerRepository;
using ETrade.Application.Repositories.OrderRepository;
using ETrade.Application.Repositories.ProductRepository;
using ETrade.Domain.Entities.Identity;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Repositories.CustomerRepository;
using ETrade.Persistence.Repositories.OrderRepository;
using ETrade.Persistence.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));
			services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.Password.RequiredLength = 3;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
			}).AddEntityFrameworkStores<AppDbContext>();

			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
		}
	}
}

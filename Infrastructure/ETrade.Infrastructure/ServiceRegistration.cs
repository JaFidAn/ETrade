using ETrade.Application.Abstractions.Token;
using ETrade.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection collection)
		{
			collection.AddScoped<ITokenHandler, TokenHandler>();
		}
	}
}

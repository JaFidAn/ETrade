using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETrade.Application.Abstractions.Token;

namespace ETrade.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection collection)
		{
			collection.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));
		}
	}
}

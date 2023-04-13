using ETrade.Application.Repositories.CustomerRepository;
using ETrade.Domain.Entities;
using ETrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories.CustomerRepository
{
	public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
	{
		public CustomerReadRepository(AppDbContext context) : base(context)
		{
		}
	}
}

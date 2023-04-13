using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : class
	{
		IQueryable<T> GetAll(); 
		IQueryable<T> GetWhere(Expression<Func<T, bool>> method); // will return List of values by specific condition
		Task<T> GetSingleAsync(Expression<Func<T, bool>> method); // will return 1 value by specific condition
		Task<T> GetByIdAsync(string id);
	}
}

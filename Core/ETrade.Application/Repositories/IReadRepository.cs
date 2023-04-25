using ETrade.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll(bool tracking = true); 
		IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); // will return List of values by specific condition
		Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); // will return 1 value by specific condition
		Task<T> GetByIdAsync(string id, bool tracking = true);
	}
}

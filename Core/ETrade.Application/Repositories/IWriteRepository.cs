﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : class
	{
		Task<bool> AddAsync(T model);
		Task<bool> AddRangeAsync(List<T> model);  
		bool Remove(T model);
		bool RemoveRange(List<T> model);
		Task<bool> RemoveAsync(string id);
		bool Update(T model);
		Task<int> SaveAsync();
	}
}

﻿using ETrade.Application.Repositories;
using ETrade.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : class
	{
		private readonly AppDbContext _context;

		public ReadRepository(AppDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll()
		{
			return Table;
		}

		public async Task<T> GetByIdAsync(string id)
		{
			return await Table.FindAsync(Guid.Parse(id));
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
		{
			return await Table.FirstOrDefaultAsync(method);
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
		{
			return Table.Where(method);
		}
	}
}

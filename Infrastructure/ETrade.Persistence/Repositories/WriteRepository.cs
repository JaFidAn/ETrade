using ETrade.Application.Repositories;
using ETrade.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class
	{
		private readonly AppDbContext _context;

		public WriteRepository(AppDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> AddRangeAsync(List<T> model)
		{
			await Table.AddRangeAsync(model);
			return true;
		}

		public bool Remove(T model)
		{
			EntityEntry<T> entityEntry = Table.Remove(model);
			return entityEntry.State == EntityState.Deleted;
		}

		public bool RemoveRange(List<T> model)
		{
			Table.RemoveRange(model);
			return true;
		}

		public async Task<bool> RemoveAsync(string id)
		{
			T model = await Table.FindAsync(id);
			return Remove(model);  //it is our created Remove() method above
		}

		public bool Update(T model)
		{
			EntityEntry<T> entityEntry = Table.Update(model);
			return entityEntry.State == EntityState.Modified;
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}

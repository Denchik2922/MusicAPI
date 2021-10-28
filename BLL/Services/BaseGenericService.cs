using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class BaseGenericService<TEntity> : IGenericService<TEntity> where TEntity : class
	{
		protected readonly MusicContext _context;
		protected readonly DbSet<TEntity> _dbSet;

		public BaseGenericService(MusicContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public async virtual Task Add(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async virtual Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public async Task<TEntity> GetById(int id)
		{
			TEntity entity = await _dbSet.FindAsync(id);
			return entity;
		}

		public async Task RemoveById(int id)
		{
			var entity = await GetById(id);
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}

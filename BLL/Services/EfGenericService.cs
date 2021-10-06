using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
	public class EfGenericService<TEntity> : IGenericService<TEntity> where TEntity : class
	{
		private readonly MusicContext _context;
		private readonly DbSet<TEntity> _dbSet;

		public EfGenericService(MusicContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public void Add(TEntity entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbSet.ToList();
		}

		public TEntity GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Remove(TEntity entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			return Include(includeProperties).ToList();
		}

		public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
			params Expression<Func<TEntity, object>>[] includeProperties)
		{
			var query = Include(includeProperties);
			return query.Where(predicate).ToList();
		}

		private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> query = _dbSet.AsNoTracking();
			return includeProperties
				.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}
	}
}

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
	public class BaseGenericService<TEntity> : IGenericService<TEntity> where TEntity : class
	{
		protected readonly MusicContext _context;
		protected readonly DbSet<TEntity> _dbSet;

		public BaseGenericService(MusicContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}

		public virtual void Add(TEntity entity)
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

		public void RemoveById(int id)
		{
			_dbSet.Remove(GetById(id));
			_context.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}

using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
		protected readonly ILogger<BaseGenericService<TEntity>> _logger;

		public BaseGenericService(MusicContext context, ILogger<BaseGenericService<TEntity>> logger)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
			_logger = logger;
		}

		public virtual void Add(TEntity entity)
		{
			try
			{
				_dbSet.Add(entity);
				_context.SaveChanges();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex,"Error adding data");
				throw new Exception("Error adding data");
			}
			
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return _dbSet.ToList();
		}

		public TEntity GetById(int id)
		{

			TEntity entity = _dbSet.Find(id);
			if (entity == null)
			{
				_logger.LogWarning($"Entity with id - {id} not found");
				throw new Exception($"Entity with id - {id} not found");
			}
			return entity;
		}

		public void RemoveById(int id)
		{
			try
			{
				_dbSet.Remove(GetById(id));
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex,"Error removing data");
				throw new Exception($"Error removing data");
			}

		}

		public void Update(TEntity entity)
		{
			try
			{
				_context.Entry(entity).State = EntityState.Modified;
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error updating data\nException {ex}");
				throw new Exception($"Error updating data");
			}
			
		}
	}
}

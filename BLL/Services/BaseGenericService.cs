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
		protected readonly ILogger<BaseGenericService<TEntity>> _logger;

		public BaseGenericService(MusicContext context, ILogger<BaseGenericService<TEntity>> logger)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
			_logger = logger;
		}

		public async virtual Task Add(TEntity entity)
		{
			try
			{
				await _dbSet.AddAsync(entity);
				await _context.SaveChangesAsync();

			}
			catch (Exception ex)
			{
				_logger.LogError(ex,"Error adding data");
				throw new Exception("Error adding data");
			}
			
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
			try
			{
				var entity = await GetById(id);
				 _dbSet.Remove(entity);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex,"Error removing data");
				throw new Exception($"Error removing data");
			}

		}

		public async Task Update(TEntity entity)
		{
			try
			{
				_context.Entry(entity).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error updating data\nException {ex}");
				throw new Exception($"Error updating data");
			}
			
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
	public interface IGenericService<TEntity> where TEntity : class
	{
        void Add(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}

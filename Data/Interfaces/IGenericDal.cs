using Common.Enums;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        TEntity Find(int id);

        List<TEntity> GetAllWithSorter<TSorter>(OrderByTypeEnum orderByType, Expression<Func<TEntity, TSorter>> sorter = null, Expression<Func<TEntity, bool>> filter = null);

        TEntity GetByFilter(Expression<Func<TEntity, bool>> filter);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}

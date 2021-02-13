using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interfaces
{
    public interface IGenericService<TEntity>
        where TEntity : class, ITable, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}

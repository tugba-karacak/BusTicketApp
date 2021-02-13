using Bussiness.Interfaces;
using Data.Concrete.EntityFrameworkCore;
using Data.Interfaces;
using Entities.Interfaces;
using System.Collections.Generic;

namespace Bussiness.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity>
        where TEntity : class, ITable, new()
    {
        private readonly Data.Interfaces.IGenericDal<TEntity> _dal;

        public GenericManager(Data.Interfaces.IGenericDal<TEntity> dal)
        {
            _dal = dal;
        }

        public void Create(TEntity entity)
        {
            _dal.Create(entity);
        }

        public List<TEntity> GetAll()
        {
            return _dal.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _dal.Find(id);
        }

        public void Remove(TEntity entity)
        {
            _dal.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dal.Update(entity);
        }
    }
}

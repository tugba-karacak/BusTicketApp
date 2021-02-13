using Common.Enums;
using Data.Concrete.EntityFrameworkCore.Context;
using Data.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Concrete.EntityFrameworkCore
{
    public class GenericDalEf<TEntity> : IGenericDal<TEntity>
        where TEntity : class, ITable, new()
    {
        private readonly BusContext _context;

        public GenericDalEf(BusContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public TEntity Find(int id)
        {
            return _context.Find<TEntity>(id);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return _context.Set<TEntity>().Where(filter).ToList();
            else
                return _context.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAllWithSorter<TSorter>( OrderByTypeEnum orderByType, Expression<Func<TEntity, TSorter>> sorter=null, Expression<Func<TEntity, bool>> filter = null)
        {
                if (orderByType == OrderByTypeEnum.ASC)
                {
                    if (filter != null)
                    {
                        return _context.Set<TEntity>().Where(filter).OrderBy(sorter).ToList();
                    }
                    else
                    {
                        return _context.Set<TEntity>().OrderBy(sorter).ToList();
                    }

                }
                else
                {
                    if (filter != null)
                    {
                        return _context.Set<TEntity>().Where(filter).OrderByDescending(sorter).ToList();
                    }
                    else
                    {
                        return _context.Set<TEntity>().OrderByDescending(sorter).ToList();
                    }
                }            
        
        }

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}

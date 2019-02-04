using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected GenericRepository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities; ;
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count)
        {
            return _entities.Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual int Count()
        {
            return _entities.Count();
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Remove(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        private DbSet<TEntity> _entities;
        private DbContext _context;
    }
}

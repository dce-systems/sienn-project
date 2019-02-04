using System;
using SIENN.Services.Abstractions;
using SIENN.DbAccess.Abstractions;
using SIENN.DbAccess.Repositories;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SIENN.Services
{
    public abstract class BaseService<TEntity, TRepository> : IBaseService<TEntity>
    where TEntity : class, IBaseEntity, new()
    where TRepository : IGenericRepository<TEntity>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected TRepository Repository;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Initialize();
        }

        private void Initialize()
        {
            Initialize(out Repository);
        }

        protected abstract void Initialize(out TRepository repository);

        public virtual TEntity Get(int id)
        {
            return Repository.Get(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var all = Repository.GetAll();

            return all.Where(predicate ?? (x => true));
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count)
        {
            var slice = Repository.GetAll().OrderBy(t => t.Id)
                                           .Skip((start - 1) * count)
                                           .Take(count);

            return slice;
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            var all = Repository.GetAll();
            var queryable = all.Where(predicate ?? (x => true));
            var slice = queryable.OrderBy(t => t.Id)
                                 .Skip((start - 1) * count)
                                 .Take(count);

            return slice;
        }

        public int Count()
        {
            return Repository.GetAll().Count();
        }

        public virtual void Add(TEntity entity)
        {
            entity.Created = DateTimeOffset.UtcNow;
            Repository.Add(entity);
            UnitOfWork.Save();
        }

        public virtual void Update(TEntity entity)
        {
            entity.Updated = DateTimeOffset.UtcNow;
            Repository.Update(entity);
            UnitOfWork.Save();
        }

        public virtual void Remove(int id)
        {
            Repository.Remove(id);
            UnitOfWork.Save();
        }

    }
}

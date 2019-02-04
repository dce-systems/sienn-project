using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SIENN.DbAccess.Abstractions;

namespace SIENN.Services.Abstractions
{
    public interface IBaseService<T> where T : class, IBaseEntity
    {
        T Get(int id);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> GetRange(int start, int count);
        IQueryable<T> GetRange(int start, int count, Expression<Func<T, bool>> predicate);

        int Count();

        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}

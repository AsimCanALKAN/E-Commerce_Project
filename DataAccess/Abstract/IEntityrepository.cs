using System;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    //class: reference type
    //IEntity: It can be IEntity or class regarding to IEntity
    //new(): Just class regarding to IEntity
    public interface IEntityrepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}


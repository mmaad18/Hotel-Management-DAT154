using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HotelManagement.DAL.Repositorys.Shared
{
    public interface IRepository< TEntity> where TEntity : class
    {
       
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entity);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void Save();
        void RefreshAll();
    }
}
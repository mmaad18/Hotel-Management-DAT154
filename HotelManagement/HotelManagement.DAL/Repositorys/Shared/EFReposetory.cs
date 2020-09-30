using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositorys.Shared
{
    public abstract class EFRepository<C, T> : IRepository <T> where T : class where C : DbContext, new()
    {
        public void RefreshAll()
        {
            foreach (var entity in Context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }


        private C _entities = new C();

        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }
        public virtual T Get(int id)
        {
           return _entities.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }
        public virtual void Add(IEnumerable<T> entity)
        {
            _entities.Set<T>().AddRange(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }
        public virtual void Delete(IEnumerable<T> entity)
        {
            _entities.Set<T>().RemoveRange(entity);
        }

        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}

using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace AspNetWebApplication.Core.Repositories
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        T ReadById(object id);
        void Update(T entity);
        void Delete(T entity);
    }

    internal class GenericRepository<TDc, T> : IGenericRepository<T>
        where T : class
        where TDc : DbContext, new()
    {
        private TDc _entities;
        private bool _disposed;

        private IDbConnection Connection
        {
            get { return _entities.Database.Connection; }
        }

        protected internal TDc Context
        {
            get { return _entities; }
            set { _entities = value; }
        }


        public GenericRepository() : this(new TDc())
        {}
        public GenericRepository(TDc context)
        {
            Context = context;
        }


        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual void Create(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public T ReadById(object id)
        {
            return _entities.Set<T>().Find(id);
        }

        public virtual void Update(T entity)
        {
            var entry = _entities.Entry(entity);
            _entities.Set<T>().Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _entities.Set<T>().Attach(entity);
            }
            _entities.Set<T>().Remove(entity);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }
    }
}
using System;
using System.Data.Entity;
using AspNetWebApplication.Core.Helper;
using AspNetWebApplication.Core.Model;

namespace AspNetWebApplication.Core.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AspNetWebApplicationEntities _context = new AspNetWebApplicationEntities(ConnectionHelper.GetConnectionString());
        private bool _disposed;

        public DbContext Context
        {
            get { return _context; }
        }


        public UnitOfWork() : this(new AspNetWebApplicationEntities(ConnectionHelper.GetConnectionString()))
        {}
        internal UnitOfWork(AspNetWebApplicationEntities context)
        {
            _context = context;
        }
        public UnitOfWork(string connectionString) : this(new AspNetWebApplicationEntities())
        {
            _context.Database.Connection.ConnectionString = connectionString;
        }


        #region Specific repositories
        private IPersonRepository_G5 y _personRepository;
        public IPersonRepository_G5 PersonRepository
        {
            get { return _personRepository ?? (_personRepository = new PersonRepository(_context)); }
        }
        #endregion


        #region Methods
        public void Save()
        {
            _context.SaveChanges();
        }

        public int ExecuteCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }
        #endregion
    }
}

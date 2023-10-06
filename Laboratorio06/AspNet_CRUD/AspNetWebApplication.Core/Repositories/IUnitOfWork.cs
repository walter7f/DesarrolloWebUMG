using System.Data.Entity;

namespace AspNetWebApplication.Core.Repositories
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }


        IPersonRepository_G5 PersonRepository { get; }


        #region Methods
        void Save();
        void Dispose();
        int ExecuteCommand(string sql, params object[] parameters);
        #endregion
    }
}

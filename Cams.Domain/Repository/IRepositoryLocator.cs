using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Querying;

namespace Cams.Domain.Repository
{
    public interface IRepositoryLocator
    {
        #region CRUD operations
        
        TEntity Add<TEntity>(TEntity instance);
        void Update<TEntity>(TEntity instance);
        void Remove<TEntity>(TEntity instance);
        
        #endregion

        #region Retrieval Operations

        TEntity GetById<TEntity> (int id);
        TEntity GetById<TEntity> (long id);
        IQueryable<TEntity> FindAll<TEntity>();

        IQueryable<TEntity> FindAll<TEntity>(int index, int count);
        IQueryable<TEntity> FindBy<TEntity>(Query query);
        IQueryable<TEntity> FindBy<TEntity>(Query query, int index, int count);
        #endregion

        IRepository<T> GetRepository<T> ();

    }
}

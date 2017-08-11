using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Cams.Common.Querying;

namespace Cams.Domain.Repository
{
    public interface IRepository<TEntity>
    {
        
        #region CRUD operations
        
        TEntity Add(TEntity instance);
        void Update(TEntity instance);
        void Remove(TEntity instance);
        
        #endregion

        #region Retrieval Operations

        TEntity GetById (long id);
        TEntity GetById (int id);
        IQueryable<TEntity> FindAll();

        int GetCount(Query query);

        //TEntity FindBy(Expression<Func<TEntity, bool>> expression);  
        //IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);  

        IQueryable<TEntity> FindAll(int index, int count);
        IQueryable<TEntity> FindBy(Query query);
        IQueryable<TEntity> FindBy(Query query, int index, int count);

        #endregion
    }
}

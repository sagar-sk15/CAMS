using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Cams.Common.Querying;

namespace Cams.Domain.Repository
{
    public abstract class RepositoryLocatorBase : IRepositoryLocator
    {
        protected Dictionary<Type, object> RepositoryMap = new Dictionary<Type, object>();

        #region IRepositoryLocator Members

        public TEntity Add<TEntity>(TEntity instance)
        {
            return GetRepository<TEntity>().Add(instance);
        }

        public void Update<TEntity>(TEntity instance)
        {
            GetRepository<TEntity>().Update(instance);
        }

        public void Remove<TEntity>(TEntity instance)
        {
            GetRepository<TEntity>().Remove(instance);
        }

        public TEntity GetById<TEntity> (long id)
        {
            return GetRepository<TEntity>().GetById(id);
        }

        public TEntity GetById<TEntity> (int id)
        {
            return GetRepository<TEntity> ().GetById (id);
        }

        public IQueryable<TEntity> FindAll<TEntity>()
        {
            return GetRepository<TEntity>().FindAll();
        }

        public int GetCount<TEntity>(Query query)
        {
            return GetRepository<TEntity>().GetCount(query);
        }

        //public TEntity FindBy<TEntity>(Expression<Func<TEntity, bool>> expression)
        //{
        //    return GetRepository<TEntity>().FindBy(expression); 
        //}

        //public IQueryable<TEntity> FilterBy<TEntity>(Expression<Func<TEntity, bool>> expression)
        //{
        //    return GetRepository<TEntity>().FilterBy(expression);
        //}

        /// <summary>
        /// Find all the entities with respect to the pageno (index) and records per page (count)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindAll<TEntity>(int index, int count)
        {
            return GetRepository<TEntity>().FindAll(index, count);
        }

        /// <summary>
        /// Get the Entities with respect to the query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindBy<TEntity>(Query query)
        {
            return GetRepository<TEntity>().FindBy(query);
        }

        /// <summary>
        /// Get the list of entities with respect to the Query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query">Criteria</param>
        /// <param name="index">Page no</param>
        /// <param name="count">No of records per page</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindBy<TEntity>(Query query, int index, int count)
        {
            return GetRepository<TEntity>().FindBy(query, index, count);
        }

        public IRepository<T> GetRepository<T> ()
        {
            var type = typeof(T);
            if (RepositoryMap.Keys.Contains (type)) return RepositoryMap[type] as IRepository<T>;
            var repository = CreateRepository<T>();
            RepositoryMap.Add(type, repository);
            return repository;
        }

        protected abstract IRepository<T> CreateRepository<T> ();

        #endregion
    }
}

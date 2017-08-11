using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Repository;
using NHibernate;
using NHibernate.Linq;
using System.Linq.Expressions;
using Cams.Common.Querying;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace Cams.Dal.Repository
{
    public class RepositoryNh<TEntity> : IRepository<TEntity>
    {

        private readonly ISession SessionInstance;

        public RepositoryNh(ISession session)
        {
            SessionInstance = session;
        }

        #region Implementation of IRepository<TEntity>

        public TEntity Add(TEntity instance)
        {

            //SessionInstance.Clear();
            SessionInstance.Save(instance);
            return instance;
        }

        public void Update(TEntity instance)
        {
            //SessionInstance.Clear();
            SessionInstance.Update(instance);
        }

        public void Remove(TEntity instance)
        {
            SessionInstance.Delete(instance);
        }

        public TEntity GetById(long id)
        {
            return SessionInstance.Get<TEntity>(id);
        }

        public TEntity GetById(int id)
        {
            return SessionInstance.Get<TEntity>(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return SessionInstance.Query<TEntity>();
            
        }

        public int GetCount(Query query)
        {
            ICriteria criteriaQuery = SessionInstance.CreateCriteria(typeof(TEntity));
            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<TEntity>(criteriaQuery);
            return criteriaQuery.List<TEntity>().Count();
        }

        public IQueryable<TEntity> FindAll(int index, int count)
        {
            ICriteria criteriaQuery = SessionInstance.CreateCriteria(typeof(TEntity));
            return criteriaQuery.SetFetchSize(count).SetFirstResult(index).List<TEntity>().AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Query query)
        {
            ICriteria criteriaQuery = SessionInstance.CreateCriteria(typeof(TEntity));

            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<TEntity>(criteriaQuery);
            criteriaQuery.SetResultTransformer(new DistinctRootEntityResultTransformer());
            return criteriaQuery.List<TEntity>().AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Query query, int index, int count)
        {
            ICriteria criteriaQuery = SessionInstance.CreateCriteria(typeof(TEntity));
            AppendCriteria(criteriaQuery);
            query.TranslateIntoNHQuery<TEntity>(criteriaQuery);
            criteriaQuery.SetFirstResult(index * count)
                         .SetFetchSize(count)
                         .SetMaxResults(count)
                        .SetResultTransformer(new DistinctRootEntityResultTransformer());
            return criteriaQuery.List<TEntity>().AsQueryable<TEntity>();
        }

        public virtual void AppendCriteria(ICriteria criteria)
        {
            //foreach(Criterion cri in criteria)
            //{
            //    if (cri.PropertyName.StartsWith("ug."))
            //    {
            //        if (typeof(TEntity) == typeof(Cams.Domain.Entities.Users.User))
            //        {
            //            criteria.CreateAlias("UserWithUserGroups", "ug");
            //            //criteria.SetFetchMode("UserWithUserGroups", FetchMode.Select);
            //        }
            //    }
            //}
        }

        #endregion
    }

}


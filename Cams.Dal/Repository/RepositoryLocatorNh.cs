using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Repository;
using NHibernate;


namespace Cams.Dal.Repository
{
    public class RepositoryLocatorNh : RepositoryLocatorBase
    {
        private readonly ISession SessionInstance;

        public RepositoryLocatorNh(ISession session)
        {
            SessionInstance = session;
        }
        
        #region Overrides of RepositoryLocatorBase

        protected override IRepository<T> CreateRepository<T>()
        {
            return new RepositoryNh<T>(SessionInstance);
        }

        #endregion
    }
}

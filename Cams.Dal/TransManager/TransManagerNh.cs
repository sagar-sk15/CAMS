using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.TransManager;
using Cams.Dal.Repository;
using NHibernate;

namespace Cams.Dal.TransManager
{
    public class TransManagerNh
        :TransManagerBase
    {
        private readonly ISession SessionInstance;

        public TransManagerNh(ISession session)
        {
            SessionInstance = session;
            Locator = new RepositoryLocatorNh(SessionInstance);
        }

        #region Overriden Base Methods

        public override void BeginTransaction()
        {
            base.BeginTransaction();
            if (SessionInstance.Transaction.IsActive) return;
            SessionInstance.BeginTransaction();
        }

        public override void CommitTransaction()
        {
            base.CommitTransaction();
            if (!SessionInstance.Transaction.IsActive) return;
            SessionInstance.Transaction.Commit();
        }

        public override void Rollback()
        {
            base.Rollback();
            if (!SessionInstance.Transaction.IsActive) return;
            SessionInstance.Transaction.Rollback();
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            // free managed resources
            if (!IsDisposed && IsInTranx)
            {
                Rollback();
            }
            Close();
            Locator = null;
            IsDisposed = true;
        }
        
        private void Close()
        {
            if (SessionInstance == null) return;
            if (!SessionInstance.IsOpen) return;
            SessionInstance.Close();
        }

        #endregion
    }
}

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Cams.Common.Message;
using Cams.Domain.Repository;
using Cams.Domain.AppServices;
using Cams.Common.Logging;

namespace Cams.Domain.TransManager
{
    public abstract class TransManagerBase : ITransManager
    {
        protected bool IsInTranx;
        public IRepositoryLocator Locator { get; set; }

        #region ITransManager Members

        public TResult ExecuteCommand<TResult> (Func<IRepositoryLocator, TResult> command) 
            //where TResult : class, Common.Message.IDtoResponseEnvelop
        {
            try
            {
                BeginTransaction();
                LoggingFactory.LogDebug("Begin Transaction");
                
                var result = command.Invoke(Locator);
                CommitTransaction();
                LoggingFactory.LogDebug("Commit Transaction");
                CheckForWarnings(result);
                return result;
            }
            catch (BusinessException exception)
            {
                if (IsInTranx)
                {
                    Rollback();
                    LoggingFactory.LogDebug("Rollback Transaction");
                }
                var type = typeof(TResult);
                var instance = Activator.CreateInstance(type, true) as IDtoResponseEnvelop;
                if (instance != null)
                {
                    instance.Response.AddBusinessException(exception);
                    LoggingFactory.LogException(instance.Response.BusinessException.ToString(), exception);
                }
                return (TResult) instance; //as TResult;
            }
            catch (Exception ex)
            {
                LoggingFactory.LogException(ex.Message, ex);
                throw ex;
            }
        }

        public virtual void BeginTransaction()
        {
            IsInTranx = true;
            return;
        }

        public virtual void CommitTransaction()
        {
            IsInTranx = false;
            return;
        }

        public virtual void Rollback()
        {
            IsInTranx = false;
            return;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected bool IsDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            // free managed resources
            if (!IsDisposed && IsInTranx)
            {
                Rollback();
            }
            Locator = null;
            IsDisposed = true;
        }

        #endregion

        #region Helper Methods

        private void CheckForWarnings<TResult>(TResult result)
        {
            var response = result as IDtoResponseEnvelop;
            if (response == null) return;
            var notifier = Container.RequestContext.Notifier;
            if (notifier.HasWarnings)
            {
                IEnumerable<BusinessWarning> warnings = notifier.RetrieveWarnings();
                response.Response.AddBusinessWarnings(warnings);

                StringBuilder strWarnings=new StringBuilder();
                warnings.ToList().ForEach(w => strWarnings.Append(w.Message));
                LoggingFactory.LogWarning(strWarnings.ToString());
            }
        }

        #endregion
    }
}

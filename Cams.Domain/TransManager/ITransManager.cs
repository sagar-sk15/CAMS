using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Repository;
using Cams.Common.Message;

namespace Cams.Domain.TransManager
{
    public interface ITransManager : IDisposable
    {
        TResult ExecuteCommand<TResult>(Func<IRepositoryLocator, TResult> command); 
            //where TResult : class, IDtoResponseEnvelop;

        void BeginTransaction();
        void CommitTransaction();
        void Rollback();
    }
}

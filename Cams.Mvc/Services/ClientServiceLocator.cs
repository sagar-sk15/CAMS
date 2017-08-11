using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services
{
    public class ClientServiceLocator : IClientServices
    {
        static readonly Object LocatorLock = new object();
        private static ClientServiceLocator InternalInstance;

        private ClientServiceLocator() { }

        public static ClientServiceLocator Instance()
        {
            if (InternalInstance == null)
            {
                lock (LocatorLock)
                {
                    if (InternalInstance == null)
                    {
                        InternalInstance = new ClientServiceLocator();
                    }
                }
            }
            return InternalInstance;
        }

        #region IClientServices Members

        public IContractLocator ContractLocator { get; private set; }

        #endregion
    }
}

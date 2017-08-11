using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.TransManager;

namespace Cams.Domain.AppServices
{
  
    public class GlobalContext : IGlobalContext
    {
        static readonly Object LocatorLock = new object();
        private static GlobalContext InternalInstance;

        private GlobalContext() { }

        public static GlobalContext Instance()
        {
            if (InternalInstance == null)
            {
                lock (LocatorLock)
                {
                    // in case of a race scenario ... check again
                    if (InternalInstance == null)
                    {
                        InternalInstance = new GlobalContext();
                    }
                }
            }
            return InternalInstance;
        }
    
        #region IGlobalContext Members

        public ITransFactory TransFactory { get; set; }

        #endregion
    }
}

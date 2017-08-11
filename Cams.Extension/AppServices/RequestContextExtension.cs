using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.AppServices;

namespace Cams.Extension.AppServices
{
    public class RequestContextExtension :IRequestContext
    {
        private BusinessNotifier BusinessNotifierInstance;

        public IBusinessNotifier Notifier
        {
            get 
            {
                if (BusinessNotifierInstance != null) return BusinessNotifierInstance;
                BusinessNotifierInstance = new BusinessNotifier();
                return BusinessNotifierInstance;
            }
        }
    }
}

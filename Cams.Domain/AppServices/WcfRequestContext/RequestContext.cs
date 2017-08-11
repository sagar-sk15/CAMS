using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Cams.Domain.AppServices.WcfRequestContext
{
    public class RequestContext : IRequestContext
    {
        public IBusinessNotifier Notifier
        {
            get
            {
                InstanceContext ic = OperationContext.Current.InstanceContext;
                InstanceCreationExtension extension = ic.Extensions.Find<InstanceCreationExtension>();
                return extension.Notifier;
            }
        }
    }
   
}

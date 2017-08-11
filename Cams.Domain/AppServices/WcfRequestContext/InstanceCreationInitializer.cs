using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Cams.Domain.AppServices.WcfRequestContext
{
    public class InstanceCreationInitializer : IInstanceContextInitializer
    {
        #region IInstanceContextInitializer Members
        
        public void Initialize(InstanceContext instanceContext, Message message)
        {
            // Add extension which contains the new instance creation index
            instanceContext.Extensions.Add(new InstanceCreationExtension(DateTime.Now));
        }
        
        #endregion
    }
}
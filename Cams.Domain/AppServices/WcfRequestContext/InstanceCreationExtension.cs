using System;
using System.ServiceModel;

namespace Cams.Domain.AppServices.WcfRequestContext
{
    public class InstanceCreationExtension : IExtension<InstanceContext>
    {
        public DateTime InstanceCreated { get; private set; }
        public BusinessNotifier Notifier { get; private set; }

        public InstanceCreationExtension(DateTime instanceCreated)
        {
            InstanceCreated = instanceCreated;
            Notifier = new BusinessNotifier();
        }

        #region IExtension<InstanceContext> Members

        public void Attach(InstanceContext owner)
        {
            // Make sure we detach when the owner is closed
            owner.Closed += (sender, args) => Detach((InstanceContext)sender);
        }

        public void Detach(InstanceContext owner)
        {
            Notifier = null;
        }

        #endregion
    }
}
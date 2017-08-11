using System;
using System.Configuration;
using System.Linq;
using Cams.Common.DependencyInjection;
using Cams.Domain.Entities;
using System.ServiceModel;
using System.Web;
using Spring.Context.Support;
using System.ServiceModel.Activation;

namespace Cams.WcfService
{
    public class ServiceFactory : ServiceHostFactory
    {
        
        static readonly Object ServiceLock = new object();
        static bool IsInitialised;

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            if (!IsInitialised) InitialiseService();
            return base.CreateServiceHost(serviceType, baseAddresses);
        }

        private void InitialiseService()
        {
            lock (ServiceLock)
            {
                if (IsInitialised) return;
                InitialiseDependecy();
                AutoMapperConfigurator.Install();
                IsInitialised = true;
            }
        }

        private void InitialiseDependecy()
        {
            string spring = @"file://" + HttpRuntime.AppDomainAppPath + ConfigurationManager.AppSettings.Get("SpringConfigFile");
            DiContext.AppContext = new XmlApplicationContext(spring);
        }

    }

}
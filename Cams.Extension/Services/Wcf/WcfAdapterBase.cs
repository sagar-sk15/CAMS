using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using Cams.Common.Message;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class WcfAdapterBase<TContract> where TContract: class, IContract
    {
        private class WcfProxy<TService>:
            ClientBase<TService> where TService : class, IContract
        {
            public TService WcfChannel
            {
                get
                {
                    return this.Channel;
                }
            }
        }

        protected TResult ExecuteCommand<TResult>(Func<TContract, TResult> command)
            where TResult : IDtoResponseEnvelop
        {
            var proxy = new WcfProxy<TContract>();     
       
            try
            {
                var result = command.Invoke(proxy.WcfChannel);
                proxy.Close();
                return result;
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }
        }
    }
}

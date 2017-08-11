using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class SubscriptionMasterServiceProxy : WcfAdapterBase<ISubscriptionMasterService>, ISubscriptionMasterService
    {
        public SubscriptionMasterDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<SubscriptionMasterDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<SubscriptionMasterDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public SubscriptionMasterDto Update(SubscriptionMasterDto subscriptionmasterDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(subscriptionmasterDto, userName));
        }

        public SubscriptionMasterDto Create(SubscriptionMasterDto subscriptionmasterDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(subscriptionmasterDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<SubscriptionMasterDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}

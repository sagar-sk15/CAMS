using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://Cams/subscriptionmasterservices/")]
    public interface ISubscriptionMasterService:IContract
    {
        [OperationContract]
        SubscriptionMasterDto GetById(int id);

        [OperationContract]
        SubscriptionMasterDto Update(SubscriptionMasterDto subscriptionmasterDto, string userName);

        [OperationContract]
        SubscriptionMasterDto Create(SubscriptionMasterDto subscriptionmasterDto, string userName);

        [OperationContract]
        EntityDtos<SubscriptionMasterDto> FindAll();

        [OperationContract]
        EntityDtos<SubscriptionMasterDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<SubscriptionMasterDto> FindByQuery(Query query);
    }
}

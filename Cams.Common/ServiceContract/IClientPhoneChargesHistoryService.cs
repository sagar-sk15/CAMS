using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    /// Exposes the ClientPhoneChargesHistory Service 
    /// </summary>
    [ServiceContract(Namespace = "http://cams/clientphonechargeshistoryservices/")]
    public interface IClientPhoneChargesHistoryService : IContract
    {
        [OperationContract]
        EntityDtos<ClientPhoneChargesHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientPhoneChargesHistoryDto> FindByQuery(Query query);
    }
}

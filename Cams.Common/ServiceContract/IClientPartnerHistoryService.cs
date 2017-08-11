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
    /// Exposes the ClientPartnerHistory services
    /// </summary>
    [ServiceContract(Namespace = "http://cams/clientpartnerhistoryservices/")]
    public interface IClientPartnerHistoryService : IContract
    {
        [OperationContract]
        EntityDtos<ClientPartnerHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientPartnerHistoryDto> FindByQuery(Query query);
    }
}

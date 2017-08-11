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
    /// Exposes the ClientCommoditiesHistory services
    /// </summary>
    [ServiceContract(Namespace = "http://cams/clientcommoditieshistoryservices/")]
    public interface IClientCommoditiesHistoryService : IContract
    {
        [OperationContract]
        EntityDtos<ClientCommoditiesHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientCommoditiesHistoryDto> FindByQuery(Query query);
    }
}

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
    /// Exposes the ClientBusinessConstitutionHistory services
    /// </summary>
    [ServiceContract(Namespace = "http://cams/clientbusinessconstitutionhistoryservices/")]
    public interface IClientBusinessConstitutionHistoryService : IContract
    {
        [OperationContract]
        EntityDtos<ClientBusinessConstitutionHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientBusinessConstitutionHistoryDto> FindByQuery(Query query);
    }
}

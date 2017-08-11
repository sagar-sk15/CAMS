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
    /// Exposes the ClientWeeklyOffDayHistory Service
    /// </summary>
    [ServiceContract(Namespace = "http://cams/clientweeklyoffdayhistoryservices/")]
    public interface IClientWeeklyOffDayHistoryService : IContract
    {
        [OperationContract]
        EntityDtos<ClientWeeklyOffDayHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientWeeklyOffDayHistoryDto> FindByQuery(Query query);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.Email;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    /// Exposes the ClientProfileChangeRequests Service 
    /// </summary>
    [ServiceContract(Namespace = "http://cams/clientprofilechangerequestservices/")]
    public interface IClientProfileChangeRequestsService : IContract
    {
        [OperationContract]
        ClientProfileChangeRequestsDto Create(ClientProfileChangeRequestsDto clientprofilechangerequestsDto, string userName);

        [OperationContract]
        EntityDtos<ClientProfileChangeRequestsDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ClientProfileChangeRequestsDto> FindByQuery(Query query);  

    }
}

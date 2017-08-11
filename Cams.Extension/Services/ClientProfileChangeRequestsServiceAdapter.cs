using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Email;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Extension.Services
{
    public class ClientProfileChangeRequestsServiceAdapter : ServiceAdapterBase<IClientProfileChangeRequestsService>, IClientProfileChangeRequestsService  
    {
        public ClientProfileChangeRequestsServiceAdapter(IClientProfileChangeRequestsService service)
            : base(service) { }

        #region Implementation of IClientProfileChangeRequestsService

        public ClientProfileChangeRequestsDto Create(ClientProfileChangeRequestsDto clientprofilechangerequestsDto , string userName)
        {
            return ExecuteCommand(() => Service.Create(clientprofilechangerequestsDto, userName));
        }

        public EntityDtos<ClientProfileChangeRequestsDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientProfileChangeRequestsDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }

        #endregion
    }
}

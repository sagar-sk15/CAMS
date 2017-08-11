using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Email;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class ClientProfileChangeRequestsServiceProxy : WcfAdapterBase<IClientProfileChangeRequestsService>, IClientProfileChangeRequestsService 
    {
        public ClientProfileChangeRequestsDto Create(ClientProfileChangeRequestsDto clientprofilechangerequestsDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(clientprofilechangerequestsDto, userName));
        }

        public EntityDtos<ClientProfileChangeRequestsDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientProfileChangeRequestsDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}

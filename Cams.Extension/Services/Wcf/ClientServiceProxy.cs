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
    public class ClientServiceProxy : WcfAdapterBase<IClientService>, IClientService 
    {
        public ClientDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<ClientDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<ClientDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public ClientDto Update(ClientDto clientDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(clientDto, userName));
        }

        public ClientDto Create(ClientDto clientDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(clientDto, userName)); 
        }

        public Cams.Common.Dto.EntityDtos<ClientDto> FindByQuery(Query query, bool populateChildObjects)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query, populateChildObjects));
        } 
    }
}

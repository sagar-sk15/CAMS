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
    public class ClientWeeklyOffDayServiceProxy : WcfAdapterBase<IClientWeeklyOffDayService>, IClientWeeklyOffDayService  
    {
        public ClientWeeklyOffDayDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<ClientWeeklyOffDayDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<ClientWeeklyOffDayDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public ClientWeeklyOffDayDto Update(ClientWeeklyOffDayDto clientweeklyoffdayDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(clientweeklyoffdayDto, userName));
        }

        public ClientWeeklyOffDayDto Create(ClientWeeklyOffDayDto clientweeklyoffdayDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(clientweeklyoffdayDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<ClientWeeklyOffDayDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}

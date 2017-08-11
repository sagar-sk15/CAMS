using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Extension.Services
{
    public class ClientWeeklyOffDayServiceAdapter : ServiceAdapterBase<IClientWeeklyOffDayService>, IClientWeeklyOffDayService 
    {
        public ClientWeeklyOffDayServiceAdapter(IClientWeeklyOffDayService service)
            : base(service) { }

        public ClientWeeklyOffDayDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public ClientWeeklyOffDayDto Update(ClientWeeklyOffDayDto clientweeklyoffdayDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(clientweeklyoffdayDto, userName));
        }

        public ClientWeeklyOffDayDto Create(ClientWeeklyOffDayDto clientweeklyoffdayDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(clientweeklyoffdayDto, userName));
        }

        public Common.Dto.EntityDtos<ClientWeeklyOffDayDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<ClientWeeklyOffDayDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientWeeklyOffDayDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

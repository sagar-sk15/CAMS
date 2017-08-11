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
    public class ClientWeeklyOffDayHistoryServiceAdapter : ServiceAdapterBase<IClientWeeklyOffDayHistoryService>, IClientWeeklyOffDayHistoryService 
    {
        public ClientWeeklyOffDayHistoryServiceAdapter(IClientWeeklyOffDayHistoryService service)
            : base(service) { }

        #region Implementation of IClientWeeklyOffDayHistoryService

        public EntityDtos<ClientWeeklyOffDayHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientWeeklyOffDayHistoryDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }

        #endregion
    }
}

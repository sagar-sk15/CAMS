using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class WeeklyOffDayProxy : WcfAdapterBase<IWeeklyOffDaysService>, IWeeklyOffDaysService
    {
        public WeeklyOffDaysDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<WeeklyOffDaysDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<WeeklyOffDaysDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public WeeklyOffDaysDto Update(WeeklyOffDaysDto offdayDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(offdayDto, userName));
        }

        public WeeklyOffDaysDto Create(WeeklyOffDaysDto offdayDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(offdayDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<WeeklyOffDaysDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}

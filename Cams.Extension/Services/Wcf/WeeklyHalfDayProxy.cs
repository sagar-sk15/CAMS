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
    public class WeeklyHalfDayProxy : WcfAdapterBase<IWeeklyHalfDayService>, IWeeklyHalfDayService
    {
        public WeeklyHalfDayDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<WeeklyHalfDayDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<WeeklyHalfDayDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public WeeklyHalfDayDto Update(WeeklyHalfDayDto halfdayDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(halfdayDto, userName));
        }

        public WeeklyHalfDayDto Create(WeeklyHalfDayDto halfdayDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(halfdayDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<WeeklyHalfDayDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class ZoneServiceProxy : WcfAdapterBase<IZoneService>, IZoneService
    {
        public ZoneDto GetById(long id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<ZoneDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<ZoneDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, 0, 0));
        }

        public ZoneDto Update(ZoneDto zoneDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(zoneDto, userName));
        }

        public ZoneDto Create(ZoneDto zoneDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(zoneDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<ZoneDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
    }
}

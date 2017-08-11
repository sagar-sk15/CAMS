using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class CommodityServiceProxy : WcfAdapterBase<ICommodityService>, ICommodityService
    {
        public CommodityDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<CommodityDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<CommodityDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public CommodityDto Update(CommodityDto commodityDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(commodityDto, userName));
        }

        public CommodityDto Create(CommodityDto commodityDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(commodityDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<CommodityDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        } 
    }
}

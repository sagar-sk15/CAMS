using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services.Wcf
{
    public class CommodityClassServiceProxy : WcfAdapterBase<ICommodityClassService>,ICommodityClassService
    {
        #region Implementation of ICommodityClassService

        public CommodityClassDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<CommodityClassDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public Cams.Common.Dto.EntityDtos<CommodityClassDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
        #endregion
    }
}

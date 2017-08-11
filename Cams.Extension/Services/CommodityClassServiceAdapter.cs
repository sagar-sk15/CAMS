using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class CommodityClassServiceAdapter : ServiceAdapterBase<ICommodityClassService>, ICommodityClassService
    {
        public CommodityClassServiceAdapter(ICommodityClassService service)
            : base(service) { }

        #region Implementation of CommodityClassServiceAdapter

        public CommodityClassDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<CommodityClassDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public Cams.Common.Dto.EntityDtos<CommodityClassDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
        #endregion
    }
}

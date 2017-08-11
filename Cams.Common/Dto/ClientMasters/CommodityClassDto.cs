using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.Dto.ClientMasters
{
    public class CommodityClassDto:DtoBase
    {
        #region Constructor
        public CommodityClassDto()
        {
            Commodities = new List<CommodityDto>();
            CommoditiesofClients = new List<ClientDto>();
        }
        #endregion 

        #region Properties
        public virtual int CommodityClassId { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<CommodityDto> Commodities { get; set; }
        public virtual IList<ClientDto> CommoditiesofClients { get; set; } 
        #endregion
    }
}

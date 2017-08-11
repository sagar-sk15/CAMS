using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientCommoditiesHistoryDto : DtoBase
    {
        #region Constructor
        public ClientCommoditiesHistoryDto() 
        {           
        }
        #endregion

        #region properties

        public virtual int ClientCommoditiesHistoryId { get; set; } 
        public virtual int CAId { get; set; }
        public virtual int CommodityClassId { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }      

        #endregion
    }
}

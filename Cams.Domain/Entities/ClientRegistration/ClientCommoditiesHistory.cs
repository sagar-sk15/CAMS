using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientCommoditiesHistory : EntityBase<int> 
    {
        #region Constructor
        public ClientCommoditiesHistory() 
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

        #region methods
        public override void Validate()
        {
            return;
        }

        #endregion
    }
}

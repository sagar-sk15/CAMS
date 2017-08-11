using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientMasters
{
    public class Commodity : EntityBase<int>
    {
        #region Constructor
        public Commodity()
        {            
        }
        #endregion 

        #region properties

        public virtual int CommodityId { get; set; }
        public virtual string Name { get; set; }
        public virtual string BotanicalName { get; set; }
        public virtual string Image { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        public virtual CommodityClass CommoditiesInCommodityClass { get; set; }
        #endregion 

        #region Methods
        public override void Validate()
        {
            return;
        }
        #endregion 
    }
}

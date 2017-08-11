using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using
Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities.ClientMasters
{
    public class CommodityClass : EntityBase<int>
    {
        #region Constructor
        public CommodityClass()
        {
            Commodities = new List<Commodity>();
            CommoditiesofClients = new List<Client>();
        }
        #endregion 

        #region properties
        public virtual int CommodityClassId { get; set; }
        public virtual string Name { get; set; } 
        public virtual bool IsActive { get; set; }
        public virtual IList<Commodity> Commodities { get; set; }
        public virtual IList<Client> CommoditiesofClients { get; set; } 
        #endregion

        #region Methods

        public override void Validate()
        {
            return;
        }

        #endregion 
    }
}

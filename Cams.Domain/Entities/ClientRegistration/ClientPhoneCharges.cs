using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities.ClientMasters;
using System.Text.RegularExpressions;
using Cams.Common;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPhoneCharges : EntityBase<int>
    {
        #region Constructor
        public ClientPhoneCharges() 
        {
                     
        }
        #endregion

        #region Properties

        public virtual int ClientPhoneChargesId { get; set; }
        public virtual Nullable<DateTime> WithEffectFromDate { get; set; }
        public virtual decimal WSFarmerAmount { get; set; }
        public virtual decimal OSFarmerAmount { get; set; }
        public virtual decimal WSTraderAmount { get; set; }
        public virtual decimal OSTraderAmount { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Client PhoneChargesOfClient { get; set; }

        #endregion 

        #region Methods
        public override void Validate()
        {
        }
        #endregion 
    }
}

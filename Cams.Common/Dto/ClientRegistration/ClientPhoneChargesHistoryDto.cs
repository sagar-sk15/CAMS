using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPhoneChargesHistoryDto : DtoBase
    {
        #region Constructor
        public ClientPhoneChargesHistoryDto() 
        {
            WithEffectFromDate = Helper.SetDefaultDate();
            WithEffectToDate = Helper.SetDefaultDate();
        }
        #endregion

        #region Properties

        public virtual int ClientPhoneChargesHistoryId { get; set; }
        public virtual int ClientPhoneChargesId { get; set; }
        public virtual int CAId { get; set; }
        public virtual DateTime WithEffectFromDate { get; set; }
        public virtual DateTime WithEffectToDate { get; set; } 
        public virtual decimal WSFarmerAmount { get; set; }
        public virtual decimal OSFarmerAmount { get; set; }
        public virtual decimal WSTraderAmount { get; set; }
        public virtual decimal OSTraderAmount { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        #endregion 
    }
}

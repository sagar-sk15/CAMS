using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPhoneChargesDto : DtoBase
    {
        #region Constructor
        public ClientPhoneChargesDto() 
        {
            WithEffectFromDate = Helper.SetDefaultDate();           
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

        public virtual ClientDto PhoneChargesOfClient { get; set; }

        #endregion 
    }
}

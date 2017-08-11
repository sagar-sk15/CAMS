using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPartnerHistoryDto : DtoBase
    {
        #region Constructor
        public ClientPartnerHistoryDto() 
        {
            JoiningDate = Helper.SetDefaultDate();
            RelievingDate = Helper.SetDefaultDate();
        }
        #endregion

        #region properties

        public virtual int ClientPartnerHistoryId { get; set; }
        public virtual int PartnerId { get; set; }
        public virtual int BusinessConstitutionId { get; set; }
        public virtual int CAId { get; set; }
        public virtual DateTime JoiningDate { get; set; }
        public virtual Nullable<DateTime> RelievingDate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }      

        #endregion
    }
}

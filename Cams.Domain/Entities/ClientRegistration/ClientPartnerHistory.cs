using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPartnerHistory :EntityBase<int>
    {
        #region Constructor
        public ClientPartnerHistory() 
        {           
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

        #region methods
        public override void Validate()
        {
            return;
        }

        #endregion
    }
}

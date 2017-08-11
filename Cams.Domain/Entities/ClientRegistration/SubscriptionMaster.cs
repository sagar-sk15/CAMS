using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class SubscriptionMaster:EntityBase<int>
    {
        #region Constructor
        public SubscriptionMaster() 
        {
            ClientSubscriptions = new List<ClientSubscription>();
        }
        #endregion

        #region Properties
        public virtual int SubscriptionId { get; set; }
        public virtual IList<ClientSubscription> ClientSubscriptions { get; set; }
        public virtual Common.SubscriptionType SubscriptionType { get; set; }
        public virtual int TotalNoOfUsers { get; set; }
        public virtual int NoOfEmployees { get; set; }
        public virtual int NoOfAuditors { get; set; }
        public virtual int NoOfAssociates { get; set; }
        public virtual decimal SubscriptionFees { get; set; }
        public virtual decimal RenewalFeesPerAnnum { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        #endregion 

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

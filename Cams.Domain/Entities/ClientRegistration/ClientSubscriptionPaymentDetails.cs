using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientSubscriptionPaymentDetails:EntityBase<int>
    {
        #region Constructor
        public ClientSubscriptionPaymentDetails() 
        {
            ClientSubscription = new List<ClientSubscription>();
        }
        #endregion

        #region Properties
        public virtual int CASubscriptionPaymentDetailsId { get; set; }
        public virtual Common.PaymentMode PaymentMode { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual bool IsRTGS { get; set; }
        public virtual bool IsStandardCheque { get; set; }
        public virtual bool IsNEFT { get; set; }
        public virtual string ChequeDDTransationNo { get; set; }
        public virtual System.Nullable<System.DateTime> ChequeDDTransactionDate { get; set; }
        public virtual Nullable<DateTime> ChequeDDClearanceDates { get; set; }              
        public virtual long CreatedBy { get; set; } 
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }        
        public virtual IList<ClientSubscription> ClientSubscription { get; set; }
        public virtual BankBranch BankBranch { get; set; }
        #endregion 

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

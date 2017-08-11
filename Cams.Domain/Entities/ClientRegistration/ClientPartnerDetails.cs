using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Users;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPartnerDetails:EntityBase<int>
    {
        #region Constructor
        public ClientPartnerDetails() 
        {
            ClientPartners = new List<Client>();
            ClientPartnerContacts = new List<ContactDetails>();
            ClientPartnerBanks = new List<ClientPartnerBankDetails>();
        }
        #endregion

        #region Properties
        public virtual int PartnerId { get; set; }      
        public virtual string Title { get; set; }
        public virtual string PartnerName { get; set; }
        public virtual string Gender { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string PAN { get; set; }
        public virtual string UID { get; set; }
        public virtual string Image { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual Nullable<DateTime> JoiningDate { get; set; }
        public virtual Nullable<DateTime> RelievingDate { get; set; }
        
        public virtual string PartnerDisplayId { get; set; }
        public virtual string MaritialStatus { get; set; } 
        public virtual string PassportNo { get; set; }
        public virtual string Place { get; set; } // check again
        public virtual Nullable<DateTime> IssuedOn { get; set; }
        public virtual Nullable<DateTime> ValidUpTo { get; set; }
        public virtual Common.PartnerType PartnerType { get; set; }
        public virtual decimal CapitalRatio { get; set; } 
        public virtual decimal ProfitRatio { get; set; }
        public virtual decimal SalaryRatio { get; set; }
        public virtual decimal LossRatio { get; set; } 
        public virtual decimal OpeningBalance { get; set; }
        public virtual Common.BalanceType BalanceType { get; set; }
        public virtual Nullable<DateTime> AsOnDate  { get; set; }         
        
        public virtual bool IsActive { get; set; }
        public virtual long CreatedBy { get; set; } 
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }


        public virtual Address ClientPartnerAddress { get; set; }
        public virtual Designation ClientPartnerDesignation { get; set; }
        public virtual IList<Client> ClientPartners { get; set; }
        public virtual IList<ContactDetails> ClientPartnerContacts { get; set; }
        public virtual ClientPartnerGuardianDetails ClientPartnerGuardian { get; set; }
        public virtual IList<ClientPartnerBankDetails> ClientPartnerBanks { get; set; }
        public virtual ClientPartnerNomineeDetails ClientPartnerNominee { get; set; }
        
        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

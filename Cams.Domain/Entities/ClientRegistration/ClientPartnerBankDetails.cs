using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientMasters;
using Cams.Domain.Entities.Users;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPartnerBankDetails : EntityBase<int>
    {
        #region Constructor
        public ClientPartnerBankDetails()  
        {
            BankDetailsOfClient = new List<ClientPartnerDetails>();
            BankContactPersonContacts = new List<ContactDetails>();
        }
        #endregion

        #region Properties

        public virtual int ClientPartnerBankId { get; set; }
        public virtual Common.AccountType Accounttype { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string StandingInstructions { get; set; }
        public virtual string BankContactPersonName { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual IList<ClientPartnerDetails> BankDetailsOfClient { get; set; }
        public virtual BankBranch BranchOfClientPartner { get; set; }
        public virtual Designation BankContactPersonDesignation { get; set; }
        public virtual IList<ContactDetails> BankContactPersonContacts { get; set; } 

        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

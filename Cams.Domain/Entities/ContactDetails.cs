using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities.ClientMasters;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities
{
    public class ContactDetails : EntityBase<long>
    {
        #region Constructor
        public ContactDetails()
        {
            ContactDetailsOfUser = new List<UserProfile>();
            ContactDetailsOfEmergencyContact = new List<UserEmergencyContactPerson>();
            ContactDetailsOfAPMC = new List<APMC>();
            ContactDetailsOfBankBranch = new List<BankBranch>();
            ContactDetailsOfClient = new List<Client>();
            ContactDetailsOfClientPrimaryContactPerson = new List<ClientPrimaryContactPerson>();
            ContactDetailsOfClientPartners = new List<ClientPartnerDetails>();
            ContactDetailsOfClientPartnerGuardian = new List<ClientPartnerGuardianDetails>();
            ContactDetailsOfClientPartnerBankContactPerson = new List<ClientPartnerBankDetails>();
            ContactDetailsOfClientPartnerNominee = new List<ClientPartnerNomineeDetails>();
            CountryCallingCode = "+91";
        }
        #endregion

        #region Properties
        public virtual long ContactDetailsId { get; set; }
        public virtual Cams.Common.ContactType ContactNoType { get; set; }       
        public virtual string CountryCallingCode { get; set; }
        public virtual string STDCode { get; set; }
        public virtual string ContactNo { get; set; }

        public virtual IList<UserProfile> ContactDetailsOfUser { get; set; }
        public virtual IList<APMC> ContactDetailsOfAPMC { get; set; }
        public virtual IList<UserEmergencyContactPerson> ContactDetailsOfEmergencyContact { get; set; }
        public virtual IList<BankBranch> ContactDetailsOfBankBranch { get; set; }
        public virtual IList<Client> ContactDetailsOfClient { get; set; }
        public virtual IList<ClientPrimaryContactPerson> ContactDetailsOfClientPrimaryContactPerson { get; set; }
        public virtual IList<ClientPartnerDetails> ContactDetailsOfClientPartners { get; set; }
        public virtual IList<ClientPartnerGuardianDetails> ContactDetailsOfClientPartnerGuardian { get; set; }
        public virtual IList<ClientPartnerBankDetails> ContactDetailsOfClientPartnerBankContactPerson { get; set; } 
        public virtual IList<ClientPartnerNomineeDetails> ContactDetailsOfClientPartnerNominee { get; set; } 
        #endregion

        #region Methods
        /// <summary>
        /// Validates the user for different businessrules
        /// </summary>
        public override void Validate()
        {
        }
        #endregion 
    }
}

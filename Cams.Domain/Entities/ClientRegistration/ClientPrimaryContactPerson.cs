using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Users;
using Cams.Common;
using System.Text.RegularExpressions;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPrimaryContactPerson : EntityBase<int>
    {
        #region Constructor
        public ClientPrimaryContactPerson() 
        {
            ClientPrimaryContacts = new List<ContactDetails>();
        }
        #endregion

        #region Properties
        public virtual int CAPrimaryContactPersonId { get; set; }
        public virtual Address ClientPrimaryContactPersonAddress { get; set; } 
        public virtual Designation ClientPrimaryContactPersonDesignation { get; set; }
        public virtual IList<ContactDetails> ClientPrimaryContacts { get; set; }
        public virtual Client PrimaryContactPersonofClient { get; set; }  
        public virtual string Title { get; set; }
        public virtual string CAPrimaryConatactPersonName { get; set; }
        public virtual string Gender { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string MothersMaidenName { get; set; }
        public virtual string PAN { get; set; }
        public virtual string UID { get; set; }
        public virtual string Image { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual bool IsSameAsCompanyAddress { get; set; }
        public virtual bool IsSameAsCompanyContact { get; set; }
        public virtual string MobileNo { get; set; } 
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; } 
        #endregion 

        #region Methods

        public override void Validate()
        {
            // Name
            if (string.IsNullOrEmpty(CAPrimaryConatactPersonName))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredName);

            // Designation
            if (ClientPrimaryContactPersonDesignation != null)
            {
                if (string.IsNullOrEmpty(ClientPrimaryContactPersonDesignation.DesignationName))
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredDesignationName);
            }

            // DOB
            if(DateOfBirth == null)
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredDOB);

            // MothersMaidenName
            if (string.IsNullOrEmpty(MothersMaidenName))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredMotherName);

            // PAN
            if (!string.IsNullOrEmpty(PAN) && PAN.Length < Constants.PANLENGTH)
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactRegExPAN);

            if (string.IsNullOrEmpty(PAN))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredPAN);

            // UID
            //if (!string.IsNullOrEmpty(UID) && !Regex.IsMatch(UID, Constants.REGEXUID))
            //    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactRegExUID);

            // PIN
            if (ClientPrimaryContactPersonAddress != null)
            {
                if (!string.IsNullOrEmpty(ClientPrimaryContactPersonAddress.PIN) && !Regex.IsMatch(ClientPrimaryContactPersonAddress.PIN, Constants.REGEXPIN))
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactRegExPIN);

                if (string.IsNullOrEmpty(ClientPrimaryContactPersonAddress.PIN))
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredPIN);
            }

            // Email
            if (!string.IsNullOrEmpty(Email1) && !Regex.IsMatch(Email1, Constants.REGEXEMAIL))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactRegExEmail1);

            if (!string.IsNullOrEmpty(Email2) && !Regex.IsMatch(Email2, Constants.REGEXEMAIL))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactRegExEmail2);

            // ContactDetails
            if (ClientPrimaryContacts != null)
            {
                foreach (ContactDetails contacts in ClientPrimaryContacts)
                {
                    if (!String.IsNullOrEmpty(contacts.ContactNo))
                    {
                        if (!Regex.IsMatch(contacts.ContactNo, Constants.REGEXCONTACTNO))
                        {
                            base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRegExContactNo);
                        }
                        if (!Regex.IsMatch(contacts.STDCode, Constants.REGEXSTDCODE))
                        {
                            base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRegExSTDCode);
                        }
                    }
                }
            }

            if (ClientPrimaryContacts != null)
            {
                int mobilenoCount = 0;
                foreach (ContactDetails contacts in ClientPrimaryContacts)
                {
                    if(ContactType.MobileNo == contacts.ContactNoType)
                    {
                        mobilenoCount++;
                        if(string.IsNullOrEmpty(contacts.ContactNo))
                        {
                            base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredMobileNo);   
                        }
                    }                    
                }
                if(mobilenoCount == 0)
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredMobileNo);                    
            }

            if (ClientPrimaryContacts == null)
            {
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientPrimaryContactErrorRequiredMobileNo);  
            }
        }
        #endregion
    }
}

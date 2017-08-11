using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Masters;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities.ClientMasters;
using System.Text.RegularExpressions;
using Cams.Common;

namespace Cams.Domain.Entities.ClientRegistration 
{
    public class Client :EntityBase<int>
    {
        #region Constructor
        public Client() 
        {
            ClientContacts = new List<ContactDetails>();
            ClientCommodities = new List<CommodityClass>();
            ClientPartners = new List<ClientPartnerDetails>();
            ClientUsers = new List<User>();
            ClientSisterConcerns = new List<ClientSisterConcern>();
            ClientTaxationAndLicenses = new List<ClientTaxationAndLicenses>();
        }
        #endregion

        #region Properties
        public virtual int CAId { get; set; }
        public virtual string DisplayClientId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual Nullable<DateTime> RegistrationDate { get; set; }
        public virtual string Alias { get; set; }
        public virtual string Image { get; set; }
        public virtual string PAN { get; set; }
        public virtual string TAN { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual string Website { get; set; }
        public virtual bool IsActive { get; set; } 
        public virtual bool IsDeleted { get; set; }
        public virtual Common.ClientStatus Status { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }        
        public virtual string APMCLicenseNo { get; set; }
        public virtual Nullable<DateTime> APMCLicenseValidUpTo { get; set; }
        public virtual int NoOfPartners { get; set; }
        public virtual decimal TDSOnSubscriptionPayment { get; set; }
        public virtual string AdditionalInfoForSubscriptionPayment { get; set; } 
        
        public virtual Address ClientAddress { get; set; }
        public virtual APMC ClientAPMC { get; set; }
        public virtual BusinessConstitution ClientBusinessConstitution { get; set; }
        public virtual ClientPrimaryContactPerson ClientPrimaryContactPerson { get; set; }
        public virtual IList<ContactDetails> ClientContacts { get; set; }
        public virtual ClientSubscription ClientSubscription { get; set; }
        public virtual long AccountManagerId { get; set; }
        public virtual User AccountManager { get; set; }
        public virtual IList<User> ClientUsers { get; set; }
        public virtual IList<CommodityClass> ClientCommodities { get; set; }
        public virtual IList<ClientPartnerDetails> ClientPartners { get; set; }
        public virtual ClientPhoneCharges ClientPhoneCharges { get; set; }
        public virtual IList<ClientSisterConcern> ClientSisterConcerns { get; set; }
        public virtual IList<ClientTaxationAndLicenses> ClientTaxationAndLicenses { get; set; }
        
        #endregion  

        #region Methods

        public override void Validate()
        {
            if (string.IsNullOrEmpty(CompanyName) )
                base.AddBrokenRule(ClientRegistrationBusinessRules.MissingCompanyName);

            // PAN
            if (!string.IsNullOrEmpty(PAN) && PAN.Length < Constants.PANLENGTH)            
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientRegExPAN);

            if (string.IsNullOrEmpty(PAN))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRequiredPAN);

            // TAN
            if (!String.IsNullOrEmpty(TAN) && TAN.Length < Constants.TANLENGTH)            
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientRegExTAN);

            // PIN
            if (ClientAddress != null)
            {
                if(!string.IsNullOrEmpty(ClientAddress.PIN) && !Regex.IsMatch(ClientAddress.PIN, Constants.REGEXPIN))
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientRegExPIN);            

                if (string.IsNullOrEmpty(ClientAddress.PIN))
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRequiredPIN);

                if (ClientAddress.CityVillage == null)
                {
                    base.AddBrokenRule(ClientRegistrationBusinessRules.MissingCityVillage);
                }
            }

            // Email
            if(!string.IsNullOrEmpty(Email1) && !Regex.IsMatch(Email1, Constants.REGEXEMAIL))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientRegExEmail1);

            if (string.IsNullOrEmpty(Email1))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRequiredEmail1);

            if(!string.IsNullOrEmpty(Email2) && !Regex.IsMatch(Email2, Constants.REGEXEMAIL))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientRegExEmail2);

            // Account Manager

            if(AccountManagerId.Equals(0))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRequiredAccountManager);

            // Client ContactDetails
            if(ClientContacts != null)
            {
                foreach(ContactDetails contacts in ClientContacts)
                {
                    if (!string.IsNullOrEmpty(contacts.ContactNo))
                    {
                        if(!Regex.IsMatch(contacts.ContactNo, Constants.REGEXCONTACTNO))
                        {
                            base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRegExContactNo); 
                        }
                        if(!Regex.IsMatch(contacts.STDCode, Constants.REGEXSTDCODE))
                        {
                            base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRegExSTDCode);
                        }
                    }
                }
            }

            // Client APMC
            if (ClientAPMC != null)
            {
                if (string.IsNullOrEmpty(ClientAPMC.Name))
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientAPMCErrorRequiredAPMCName);
            }

            if(string.IsNullOrEmpty(APMCLicenseNo))
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientAPMCErrorRequiredAPMCLicenseNo);

            if (APMCLicenseValidUpTo == null)
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientAPMCErrorRequiredAPMCLicenseNoValidUpToDate);
            else
            {
                DateTime dtApmcDt =Convert.ToDateTime(APMCLicenseValidUpTo) ;
                
                if (dtApmcDt <= DateTime.Today)
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientAPMCErrorAPMCLicenseNoValidUpToDate);

            }

            if(ClientCommodities != null)
            {
                if (ClientCommodities.Count > Constants.CLIENTMAXIMUMCOMMOCITYCLASS)
                {
                    base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorCommodityClass);
                }
            }

            if (ClientCommodities == null)
                base.AddBrokenRule(ClientRegistrationBusinessRules.ClientErrorRequiredCommodityClass);

            // Client Primary Contact Person 
            if (ClientPrimaryContactPerson != null)
            {
                ClientPrimaryContactPerson.Validate();            
            }
        }
        
        #endregion
    }
}

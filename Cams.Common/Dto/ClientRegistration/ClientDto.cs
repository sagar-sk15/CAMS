using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.Masters;
using Cams.Common.Message;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientDto:DtoBase
    {
       #region Constructor
        public ClientDto() 
        {
            ClientContacts = new List<ContactDetailsDto>();
            ClientCommodities = new List<CommodityClassDto>();
            ClientPartners = new List<ClientPartnerDetailsDto>();
            ClientUsers = new List<UserDto>();
            ClientPrimaryContactPerson = new ClientPrimaryContactPersonDto();
            ClientSisterConcerns = new List<ClientSisterConcernDto>();
            ClientTaxationAndLicenses = new List<ClientTaxationAndLicensesDto>();
            APMCLicenseValidUpTo = DateTime.Today;
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

       public virtual AddressDto ClientAddress { get; set; }
       public virtual APMCDto ClientAPMC { get; set; }
       public virtual BusinessConstitutionDto ClientBusinessConstitution { get; set; }
       public virtual ClientPrimaryContactPersonDto ClientPrimaryContactPerson { get; set; }
       public virtual IList<ContactDetailsDto> ClientContacts { get; set; }
       public virtual ClientSubscriptionDto ClientSubscription { get; set; }
       public virtual UserDto AccountManager { get; set; }
       public virtual long AccountManagerId { get; set; }
       public virtual IList<UserDto> ClientUsers { get; set; }
       public virtual IList<CommodityClassDto> ClientCommodities { get; set; }
       public virtual IList<ClientPartnerDetailsDto> ClientPartners { get; set; }
       public virtual ClientPhoneChargesDto ClientPhoneCharges { get; set; }
       public virtual IList<ClientSisterConcernDto> ClientSisterConcerns { get; set; }
       public virtual IList<ClientTaxationAndLicensesDto> ClientTaxationAndLicenses { get; set; }

       #endregion  
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.Dto
{
    public class ContactDetailsDto : DtoBase
    {
        public ContactDetailsDto()
        {
            ContactDetailsOfUser = new List<UserProfileDto>();
            ContactDetailsOfEmergencyContact = new List<UserEmergencyContactPersonDto>();
            ContactDetailsOfBankBranch = new List<BankBranchDto>();
            CountryCallingCode = "+91";
            ContactDetailsOfAPMC = new List<APMCDto>();
            ContactDetailsOfClient = new List<ClientDto>();
            ContactDetailsOfClientPrimaryContactPerson = new List<ClientPrimaryContactPersonDto>();
            ContactDetailsOfClientPartners = new List<ClientPartnerDetailsDto>();
            ContactDetailsOfClientPartnerGuardian = new List<ClientPartnerGuardianDetailsDto>();
            ContactDetailsOfClientPartnerBankContactPerson = new List<ClientPartnerBankDetailsDto>();
            ContactDetailsOfClientPartnerNominee = new List<ClientPartnerNomineeDetailsDto>();
        }

        public virtual long ContactDetailsId { get; set; }
        public virtual Cams.Common.ContactType ContactNoType { get; set; }
        //public virtual CountryDto CountryCode { get; set; }
        public virtual string CountryCallingCode { get; set; }
        public virtual string STDCode { get; set; }
        public virtual string ContactNo { get; set; }
        
        public virtual IList<UserProfileDto> ContactDetailsOfUser { get; set; }
        public virtual IList<UserEmergencyContactPersonDto> ContactDetailsOfEmergencyContact { get; set; }
        public virtual IList<BankBranchDto> ContactDetailsOfBankBranch { get; set; }
        public virtual IList<APMCDto> ContactDetailsOfAPMC { get; set; }
        public virtual IList<ClientDto> ContactDetailsOfClient { get; set; }
        public virtual IList<ClientPrimaryContactPersonDto> ContactDetailsOfClientPrimaryContactPerson { get; set; }
        public virtual IList<ClientPartnerDetailsDto> ContactDetailsOfClientPartners { get; set; }
        public virtual IList<ClientPartnerGuardianDetailsDto> ContactDetailsOfClientPartnerGuardian { get; set; }
        public virtual IList<ClientPartnerBankDetailsDto> ContactDetailsOfClientPartnerBankContactPerson { get; set; }
        public virtual IList<ClientPartnerNomineeDetailsDto> ContactDetailsOfClientPartnerNominee { get; set; } 
    }
}

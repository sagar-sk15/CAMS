using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.Masters;

namespace Cams.Common.Dto.Address
{
    public class AddressDto : DtoBase
    {
        public AddressDto()
        {
        }
        public virtual long AddressId { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual CityVillageDto CityVillage { get; set; }
        public virtual string PIN { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
       
        public virtual Cams.Common.Dto.User.UserProfileDto AddressOfUser { get; set; }
        public virtual Cams.Common.Dto.User.UserEmergencyContactPersonDto AddressOfEmergencyContact { get; set; }
        public virtual Cams.Common.Dto.ClientMasters.BankBranchDto AddressofBankBranch { get; set; }
        public virtual Cams.Common.Dto.Masters.APMCDto AddressofAPMC { get; set; }
        public virtual Cams.Common.Dto.ClientRegistration.ClientDto AddressofClient { get; set; }
        public virtual Cams.Common.Dto.ClientRegistration.ClientPrimaryContactPersonDto AddressofClientPrimaryContactPerson { get; set; }
        public virtual Cams.Common.Dto.ClientRegistration.ClientPartnerDetailsDto AddressofClientPartners { get; set; }
        public virtual Cams.Common.Dto.ClientRegistration.ClientPartnerGuardianDetailsDto AddressofClientPartnerGuardian { get; set; }

    }
}

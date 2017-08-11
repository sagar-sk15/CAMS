using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto;

namespace Cams.Common.Dto.User
{
    public class UserProfileDto : DtoBase
    {
        public UserProfileDto()
        {
            ContactNos = new List<ContactDetailsDto>();
            PassportValidFromDate = Helper.SetDefaultDate();
            PassportValidToDate = Helper.SetDefaultDate();
            DateOfJoining = Helper.SetDefaultDate();
        }

        public virtual long UserProfileId { get; set; }
        public virtual Address.AddressDto UserAddress { get; set; }        
        public virtual UserEmergencyContactPersonDto UserEmergencyContactPerson { get; set; }
        public virtual IList<ContactDetailsDto> ContactNos { get; set; }
        public virtual UserDto ProfileOfUser { get; set; }
        public virtual string Gender { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual string UID { get; set; }
        public virtual string PAN { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual string PassportPlace { get; set; }
        public virtual Nullable<DateTime> PassportValidFromDate { get; set; }
        public virtual Nullable<DateTime> PassportValidToDate { get; set; }
        public virtual string BloodGroup { get; set; }
        public virtual Nullable<DateTime> DateOfJoining { get; set; }
        public virtual string PFNo { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

    }
}

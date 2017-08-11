using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.User;

namespace Cams.Common.Dto.Address
{
    public class UserAddressDto : DtoBase
    {
        public UserAddressDto()
        {
            //UserAddress = new UserProfileDto();
            //UserContactPersonAddress = new UserContactPersonDto();
        }

        public virtual  UserProfileDto UserAddress { get; set; }
        public virtual UserEmergencyContactPersonDto UserEmergencyContactPersonAddress { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual int Country { get; set; } // later on replace with country dto
        public virtual int StateandUT { get; set; } // later on replace with state and  UT dto        
        public virtual int CityVillage { get; set; } // later on replace with city village dto
        public virtual Nullable<int> PIN { get; set; }
        public virtual int ContactNoType { get; set; }
        public virtual int CountryCode { get; set; }
        public virtual int StdCode { get; set; }
        public virtual int ContactNo { get; set; }
        public virtual string Email { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}

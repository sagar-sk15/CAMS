using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.User;

namespace Cams.Common.Dto.User
{
    public class UserContactPersonDto : DtoBase
    {

        public UserContactPersonDto()
        {
            UserContactPerson = new UserProfileDto();
            ContactPersonAddress = new Address.UserAddressDto();
            ContactPersonRelationshipWithUser = new RelationshipDto();
        }
             
        public UserProfileDto UserContactPerson { get; set; }
        public Address.UserAddressDto ContactPersonAddress { get; set; }
        public RelationshipDto ContactPersonRelationshipWithUser { get; set; }
        public string CPName { get; set; }
        public Nullable<int> MobileNo { get; set; } // discuss on country code pre populate feild
        public Nullable<int> StdCode { get; set; }
        public Nullable<int> LandlineNo { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
       
    }
}

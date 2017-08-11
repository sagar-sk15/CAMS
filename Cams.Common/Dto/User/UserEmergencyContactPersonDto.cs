using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.User;

namespace Cams.Common.Dto.User
{
    public class UserEmergencyContactPersonDto : DtoBase
    {

        public UserEmergencyContactPersonDto()
        {
            Contacts = new List<ContactDetailsDto>();
        }

        public virtual long UserEmergencyContactPersonId { get; set; }
        public virtual UserProfileDto ContactPersonOfUser { get; set; }
        public virtual Address.AddressDto ContactPersonAddress { get; set; }
        public virtual RelationshipDto ContactPersonRelationshipWithUser { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<ContactDetailsDto> Contacts { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
       
    }
}

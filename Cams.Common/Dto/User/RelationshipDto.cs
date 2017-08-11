using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.Dto.User
{
    public class RelationshipDto :DtoBase
    {
        public RelationshipDto()
        {
            EmergencyContactPersonRelationshipWithUser = new List<UserEmergencyContactPersonDto>();
            CPGuardianRelationshipWithClientPartner = new List<ClientPartnerGuardianDetailsDto>();
            NomineeRelationshipWithClientPartner = new List<ClientPartnerNomineeDetailsDto>();
        }

        public virtual int RelationshipId { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        
        public virtual IList<UserEmergencyContactPersonDto> EmergencyContactPersonRelationshipWithUser { get; set; }
        public virtual IList<ClientPartnerGuardianDetailsDto> CPGuardianRelationshipWithClientPartner { get; set; }
        public virtual IList<ClientPartnerNomineeDetailsDto> NomineeRelationshipWithClientPartner { get; set; }   
    }
}

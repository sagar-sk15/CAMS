using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.User;
using Cams.Common.Dto;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPartnerGuardianDetailsDto:DtoBase
    {
        #region Constructor
        public ClientPartnerGuardianDetailsDto() 
        {
            ClientPartnerGuardianContacts = new List<ContactDetailsDto>();
            DateOfBirth = Helper.SetDefaultDate();
        }
        #endregion

        #region Properties

        public virtual int ClientPartnerGuardianId { get; set; }
        public virtual AddressDto ClientPartnerGuardianAddress { get; set; }
        public virtual IList<ContactDetailsDto> ClientPartnerGuardianContacts { get; set; }
        public virtual ClientPartnerDetailsDto GuardianofClientPartner { get; set; }
        public virtual RelationshipDto GuardianRelationshipWithClientPartner { get; set; }
        public virtual string Title { get; set; }
        public virtual string GuardianName { get; set; }
        public virtual string Gender { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string PAN { get; set; }
        public virtual string UID { get; set; }
        public virtual string Image { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        #endregion
    }
}

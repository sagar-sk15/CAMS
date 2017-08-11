using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.User;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPartnerNomineeDetailsDto : DtoBase
    {
        #region Constructor
        public ClientPartnerNomineeDetailsDto()  
        {
            ClientPartnerNomineeContacts = new List<ContactDetailsDto>();
            DateOfBirth = Helper.SetDefaultDate();
            IssuedOn = Helper.SetDefaultDate();
            ValidUpTo = Helper.SetDefaultDate();
        }
        #endregion

        #region Properties

        public virtual int ClientPartnerNomineeId { get; set; }     
        public virtual string Title { get; set; }
        public virtual string PartnerNomineeName { get; set; } 
        public virtual string Gender { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string PAN { get; set; }
        public virtual string UID { get; set; }
        public virtual string Image { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual string MaritialStatus { get; set; } 
        public virtual string PassportNo { get; set; }
        public virtual string Place { get; set; } // check again
        public virtual Nullable<DateTime> IssuedOn { get; set; }
        public virtual Nullable<DateTime> ValidUpTo { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual AddressDto ClientPartnerNomineeAddress { get; set; }
        public virtual RelationshipDto NomineeRelationshipWithClientPartner { get; set; }
        public virtual ClientPartnerDetailsDto NomineeOfClientPartner { get; set; }
        public virtual IList<ContactDetailsDto> ClientPartnerNomineeContacts { get; set; }
              

        #endregion
    }
}

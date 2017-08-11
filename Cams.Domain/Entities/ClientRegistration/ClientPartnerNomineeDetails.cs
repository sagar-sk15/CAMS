using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Users;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPartnerNomineeDetails : EntityBase<int> 
    {
        #region Constructor
        public ClientPartnerNomineeDetails()  
        {
            ClientPartnerNomineeContacts = new List<ContactDetails>();
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

        public virtual Address ClientPartnerNomineeAddress { get; set; }
        public virtual Relationship NomineeRelationshipWithClientPartner { get; set; }
        public virtual ClientPartnerDetails NomineeOfClientPartner { get; set; }
        public virtual IList<ContactDetails> ClientPartnerNomineeContacts { get; set; }
              

        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

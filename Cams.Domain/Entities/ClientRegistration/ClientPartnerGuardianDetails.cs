using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.Users;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientPartnerGuardianDetails : EntityBase<int> 
    {
        #region Constructor
        public ClientPartnerGuardianDetails() 
        {
            ClientPartnerGuardianContacts = new List<ContactDetails>();
        }
        #endregion

        #region Properties
       
        public virtual int ClientPartnerGuardianId { get; set; }
        public virtual Address ClientPartnerGuardianAddress { get; set; }
        public virtual IList<ContactDetails> ClientPartnerGuardianContacts { get; set; }
        public virtual ClientPartnerDetails GuardianofClientPartner { get; set; }
        public virtual Relationship GuardianRelationshipWithClientPartner { get; set; } 
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

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

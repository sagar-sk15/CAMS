using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities.Users
{
    public class Relationship : EntityBase<int>
    {
        #region Constructor
        public Relationship()
        {
            EmergencyContactPersonRelationshipWithUser = new List<UserEmergencyContactPerson>();
            CPGuardianRelationshipWithClientPartner = new List<ClientPartnerGuardianDetails>();
            NomineeRelationshipWithClientPartner = new List<ClientPartnerNomineeDetails>();
        }
        #endregion

        #region Properties
        public virtual int RelationshipId { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual IList<UserEmergencyContactPerson> EmergencyContactPersonRelationshipWithUser { get; set; }
        public virtual IList<ClientPartnerGuardianDetails> CPGuardianRelationshipWithClientPartner { get; set; }
        public virtual IList<ClientPartnerNomineeDetails> NomineeRelationshipWithClientPartner { get; set; }   
        #endregion

        #region Methods
        /// <summary>
        /// Validates the user for different businessrules
        /// </summary>
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                base.AddBrokenRule(RelationshipBusinessRules.RelationshipNameRequired);
                base.IsValidForBasicMandatoryFields = false;
            }
        }
        #endregion 
    }
}

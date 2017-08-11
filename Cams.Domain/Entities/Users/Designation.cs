using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities.Users
{
    public class Designation : EntityBase<int>
    {
        #region Constructor
        public Designation()
        {
            UsersWithDesignation = new List<User>();
            ClientPrimaryContactPersonWithDesignation = new List<ClientPrimaryContactPerson>();
            ClientPartnerWithDesignation = new List<ClientPartnerDetails>();
            ClientPartnerBankContactPersonWithDesignation = new List<ClientPartnerBankDetails>();
        }
        #endregion

        #region Properties
             
        public virtual int DesignationId { get; set; }
        public virtual string DesignationName { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual IList<User> UsersWithDesignation { get; set; }
        public virtual IList<ClientPrimaryContactPerson> ClientPrimaryContactPersonWithDesignation { get; set; }
        public virtual IList<ClientPartnerDetails> ClientPartnerWithDesignation { get; set; }
        public virtual IList<ClientPartnerBankDetails> ClientPartnerBankContactPersonWithDesignation { get; set; } 
        
        #endregion

        #region Methods
        /// <summary>
        /// Validates the user for different businessrules
        /// </summary>
        public override void Validate()
        {
            if (string.IsNullOrEmpty(DesignationName))
            {
                base.AddBrokenRule(DesignationBusinessRules.DesignationNameRequired);
                base.IsValidForBasicMandatoryFields = false;
            }
        }
        #endregion
    }
}

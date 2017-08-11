using System;
using Cams.Domain.Repository;
using Cams.Common.Dto.Address;
using AutoMapper;
using Cams.Domain.Entities.Masters;
using System.Collections.Generic;
using Cams.Domain.Entities.ClientMasters;
using Cams.Common.Dto.ClientMasters;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities
{
    public class Address : EntityBase<long>
    {
        #region Constructor
        public Address() {}
        #endregion

        #region Properties
        public virtual long AddressId { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual CityVillage CityVillage { get; set; }
        public virtual string PIN { get; set; }        
        
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual Users.UserProfile AddressOfUser { get; set; }
        public virtual Users.UserEmergencyContactPerson AddressOfEmergencyContact { get; set; }
        public virtual APMC AddressofAPMC { get; set; }
        public virtual BankBranch AddressofBankBranch { get; set; }
        public virtual Client AddressofClient { get; set; }
        public virtual ClientPrimaryContactPerson AddressofClientPrimaryContactPerson { get; set; }
        public virtual ClientPartnerDetails AddressofClientPartners { get; set; }
        public virtual ClientPartnerGuardianDetails AddressofClientPartnerGuardian { get; set; }

        #endregion 

        #region Methods
        public override void Validate()
        {            
            if (String.IsNullOrEmpty(AddressLine1))
                base.AddBrokenRule(AddressBusinessRules.AddressLine1Required);

            if (CityVillage==null)
                base.AddBrokenRule(AddressBusinessRules.CityRequired);

            if (String.IsNullOrEmpty(PIN))
                base.AddBrokenRule(AddressBusinessRules.ZipCodeRequired);
        }
               
        
        #endregion
    }
}

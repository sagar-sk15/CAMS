﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.User;
using Cams.Common.Dto.Address;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPrimaryContactPersonDto:DtoBase
    {
        #region Constructor
        public ClientPrimaryContactPersonDto() 
        {
            ClientPrimaryContacts = new List<ContactDetailsDto>();
            DateOfBirth = Helper.SetDefaultDate();
        }
        #endregion

        #region Properties
        public virtual int CAPrimaryContactPersonId { get; set; }
        public virtual AddressDto ClientPrimaryContactPersonAddress { get; set; } 
        public virtual DesignationDto ClientPrimaryContactPersonDesignation { get; set; }
        public virtual IList<ContactDetailsDto> ClientPrimaryContacts { get; set; }
        public virtual ClientDto PrimaryContactPersonofClient { get; set; }  
        public virtual string Title { get; set; }
        public virtual string CAPrimaryConatactPersonName { get; set; }
        public virtual string Gender { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string MothersMaidenName { get; set; }
        public virtual string PAN { get; set; }
        public virtual string UID { get; set; }
        public virtual string Image { get; set; }
        public virtual string MobileNo { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual bool IsSameAsCompanyAddress { get; set; }
        public virtual bool IsSameAsCompanyContact { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; } 
        #endregion 
    }
}

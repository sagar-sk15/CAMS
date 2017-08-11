using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientRegistration;
using Cams.Web.MVCRazor.Models.Shared;

namespace Cams.Web.MVCRazor.Models.BusinessRegistration
{
    public class BusinessRegistrationModel: ClientDto
    {
        #region Constructor
        public BusinessRegistrationModel()
        {
            CompanyAddress = new AddressReadOnlyViewModel("");
            CompanyContacts = new ContactsReadOnlyViewModel("");
            PrimaryContactsAddress = new AddressReadOnlyViewModel("PCP");
            PrimaryContactsContacts = new ContactsReadOnlyViewModel("PCP");
            PrimaryContactsContacts.IsWebsiteApplicable = false;
            ApmcAddress = new AddressReadOnlyViewModel("APMC");
            ApmcContacts = new ContactsReadOnlyViewModel("APMC");
            
            base.ClientPrimaryContactPerson = new ClientPrimaryContactPersonDto { 
                ClientPrimaryContactPersonDesignation = new Common.Dto.User.DesignationDto()
            };

            base.ClientAPMC = new Common.Dto.Masters.APMCDto();
        }
        #endregion

        #region Properties
        public int hdnCurrentTab { get; set; }
        public AddressReadOnlyViewModel CompanyAddress;
        public ContactsReadOnlyViewModel CompanyContacts;
        public AddressReadOnlyViewModel PrimaryContactsAddress;
        public ContactsReadOnlyViewModel PrimaryContactsContacts;
        public AddressReadOnlyViewModel ApmcAddress;
        public ContactsReadOnlyViewModel ApmcContacts;
        #endregion

        #region Static Methods

        #endregion
    }
}
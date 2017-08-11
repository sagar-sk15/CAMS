using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.ClientRegistration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.Models.Masters;
using Cams.Web.MVCRazor.Models.Shared;
using Cams.Common;

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public partial class ClientRegistrationModel : ClientDto
    {
        public ClientRegistrationModel()
        {
            StateDistrictPlacesControlNames = new List<Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel>();
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel(""));
            designationModel = new List<DesignationModel>();
            dOBnAgeModellist = new List<DOBnAgeModel>();

            if (!IsActive)
                RegistrationDate = null;

            #region Company Profile
            ClientContacts = new List<ContactDetailsDto>();
            ClientContacts.Add(new ContactDetailsDto()
            {
                ContactNoType = Common.ContactType.MobileNo,
                ContactNo = "",
                STDCode = "020",
                CountryCallingCode = "+91"
            });
            #endregion

            #region Initialize Primary Contact Person
            string PCPPrefix = "PCP";
            ClientPrimaryContactPerson = new ClientPrimaryContactPersonDto();
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel(PCPPrefix));
            StateDistrictPlacesControlNames[1].LeftLabelsClassName = "width100";
            designationModel.Add(new DesignationModel(PCPPrefix));
            dOBnAgeModellist.Add(new DOBnAgeModel(PCPPrefix));
            dOBnAgeModellist[0].MaxDate = DateTime.Today;
            dOBnAgeModellist[0].Width = 110;
            ClientPrimaryContactPerson.ClientPrimaryContacts = new List<ContactDetailsDto>();
            ClientPrimaryContactPerson.ClientPrimaryContacts.Add(new ContactDetailsDto()
            {
                ContactNoType = Common.ContactType.MobileNo,
                ContactNo = "",
                STDCode = "020",
                CountryCallingCode = "+91"
            });
            #endregion

            #region Client APMC
            ClientAPMC = new APMCDto();
            GetAllCommodities();
            ApmcModel = new APMCModel();
            #endregion

            #region Subscription Details
            SubscriptionMasterList = getSubscriptionMaster();
            ClientSubscription = new ClientSubscriptionDto();
            ClientSubscription.SubscriptionMaster = new SubscriptionMasterDto();
            ClientSubscription.SubscriptionPeriodFromDate = DateTime.Now;
            ClientSubscription.SubscriptionPeriodToDate = DateTime.Now;
            ClientSubscription.ActivationDate = DateTime.Now;
            #endregion

            #region Business Constitution
            ClientBusinessConstitution = new BusinessConstitutionDto();
            businessConstitutionModel = new BusinessConstitutionModel();
            businessConstitutionModel.ClientPartners = new List<ClientPartnerDetailsDto>();
            ClientPartners = new List<ClientPartnerDetailsDto>();
            #endregion

            #region ClientSubscriptionPaymentDetails
            ClientSubscriptionPaymentDetailsModel = new List<ClientSubscriptionPaymentDetailsModel>();
            ClientSubscriptionPaymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.Cash });
            ClientSubscriptionPaymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.Cheque});
            ClientSubscriptionPaymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.Online});
            ClientSubscriptionPaymentDetailsModel.Add(new ClientSubscriptionPaymentDetailsModel { PaymentMode = PaymentMode.DD });
            #endregion

            CompanyAddress = new AddressReadOnlyViewModel("");
            CompanyContacts = new ContactsReadOnlyViewModel("");
            PrimaryContactsAddress = new AddressReadOnlyViewModel("PCP");
            PrimaryContactsContacts = new ContactsReadOnlyViewModel("PCP");
            APMCAddress= new AddressReadOnlyViewModel("APMC");
            APMCContacts = new ContactsReadOnlyViewModel("APMC");
            //#region Account Manager
            //accountManagerModel = new AccountManagerModel();
            //#endregion


        }
        public override int CAId { get; set; }
        public int APMCId { get; set; }
        public override string DisplayClientId { get; set; }
        public string mode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyNameRequired")]
        [RegularExpression(@"^[a-zA-Z0-9&@,'\(\)\.\s-]{6,200}$", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyNameRegEx")]
        public override string CompanyName { get; set; }
        
        [DefaultValue("M/s.")]
        public string Title;

        //[Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyAliasNameRequired")]
        public override string Alias { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyPANRequired")]
        public override string PAN { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyTANRequired")]
        public override string TAN { get; set; }

        public override Nullable<DateTime> RegistrationDate { get; set; }

        public override string Image { get; set; }

        public override AddressDto ClientAddress { get; set; }

        public override IList<ContactDetailsDto> ClientContacts { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyEmailRequired")]
        [RegularExpression(Constants.REGEXEMAIL, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyEmailRegEx")]
        public override string Email1 { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyEmailRequired")]
        [RegularExpression(Constants.REGEXEMAIL, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CLRCompanyEmailRegEx")]
        public override string Email2 { get; set; }

        public override string Website { get; set; }

        public IList<Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel> StateDistrictPlacesControlNames;

        public APMCModel ApmcModel;

        public override DateTime? APMCLicenseValidUpTo { get; set; }

        public IList<ClientSubscriptionPaymentDetailsModel> ClientSubscriptionPaymentDetailsModel { get; set; }
        public BusinessConstitutionModel businessConstitutionModel { get; set; }
        //public AccountManagerModel accountManagerModel;
        public int hdnCurrentTab { get; set; }

        public string IsDDChecked { get; set; }
        public string IsCashChecked { get; set; }
        public string IsChequeChecked { get; set; }
        public string IsOnlineChecked { get; set; }

        //used in case of View ClientRegistration
        public string RegistrationDateString { get; set; }
        public string PrimaryContactPersonDOBString { get; set; }
        public string APMCValiduptoString { get; set; }
        public string SubscriptionPeriodFromDateString { get; set; }
        public string SubscriptionPeriodToDateString { get; set; }
        public string SubscriptionPeriodActivationDateString { get; set; }

        public AddressReadOnlyViewModel CompanyAddress;
        public ContactsReadOnlyViewModel CompanyContacts;
        public AddressReadOnlyViewModel PrimaryContactsAddress;
        public ContactsReadOnlyViewModel PrimaryContactsContacts;
        public AddressReadOnlyViewModel APMCAddress;
        public ContactsReadOnlyViewModel APMCContacts;
    }
}
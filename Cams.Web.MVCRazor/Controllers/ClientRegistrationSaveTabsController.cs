using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Web.MVCRazor.APMCMasterServiceReference;
using Cams.Web.MVCRazor.Helpers;
using Cams.Common;
using Cams.Web.MVCRazor.Models.ClientRegistration;
using Cams.Web.MVCRazor.Models.Shared;
using Cams.Web.MVCRazor.ClientServiceReference;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto;
using DevExpress.Web.Mvc;
using Cams.Common.Dto.Masters;
using Cams.Web.MVCRazor.DesignationServiceReference;
using Cams.Web.MVCRazor.CityVillageServiceReference;
using System.Text.RegularExpressions;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientAccountController : CommonController
    {
        #region Save Client Registration Details
        public void SaveCompanyProfile(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            //var currentIndex = Request.Params["currentIndex"]!= null ? Request.Params["currentIndex"] :"";
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");
            companyProfile.CompanyName = GetValueFromRequestParams("CompanyName");
            companyProfile.Alias = GetValueFromRequestParams("Alias");
            companyProfile.PAN = GetValueFromRequestParams("PAN");
            companyProfile.TAN = GetValueFromRequestParams("TAN");
            companyProfile.Email1 = GetValueFromRequestParams("Email1");
            companyProfile.Email2 = GetValueFromRequestParams("Email2");
            companyProfile.Website = GetValueFromRequestParams("Website");

            if (Request.IsAjaxRequest())
            {
                companyProfile.ClientAddress = new Common.Dto.Address.AddressDto
                {
                    AddressLine1 = GetValueFromRequestParams("AddressLine1")
                };
                int cityVillageId = (Request.Params["CityVillageId"]) != null ? Convert.ToInt32(Request.Params["CityVillageId"]) : 0;
                if (cityVillageId != 0)
                {
                    CityVillageServiceReference.CityVillageServiceClient cityVillageServiceClient = new CityVillageServiceClient();
                    CityVillageDto cityVillageDto = cityVillageServiceClient.GetById(cityVillageId);
                    companyProfile.ClientAddress.CityVillage = cityVillageDto;
                }
                companyProfile.ClientAddress.PIN = GetValueFromRequestParams("PIN");
                companyProfile.ClientContacts = GetContactsFromString(Request.Params["contactDetails"]);
            }
            else
            {
                companyProfile.ClientAddress = new Common.Dto.Address.AddressDto
                {
                    AddressLine1 = clientRegistrationModel.ClientAddress.AddressLine1
                };
                int cityVillageId = clientRegistrationModel.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue;
                if (cityVillageId != 0)
                {
                    CityVillageServiceReference.CityVillageServiceClient cityVillageServiceClient = new CityVillageServiceClient();
                    CityVillageDto cityVillageDto = cityVillageServiceClient.GetById(cityVillageId);
                    companyProfile.ClientAddress.CityVillage = cityVillageDto;
                }
                companyProfile.ClientAddress.PIN = clientRegistrationModel.ClientAddress.PIN;
                companyProfile.ClientContacts = clientRegistrationModel.ClientContacts;
            }
            if (Session["ClientLogoUploadedImageFileName"] != null)
            {
                companyProfile.Image = Session["ClientLogoUploadedImageFileName"].ToString();
            }
            Session["CompanyProfile"] = companyProfile;
        }

        public ClientRegistrationModel GetClientModelFromSession()
        {
            if (Session["CompanyProfile"] != null)
            {
                return (ClientRegistrationModel)Session["CompanyProfile"];
            }
            else
                return new ClientRegistrationModel();
        }

        public void SavePrimaryContactDetails(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");
            ClientPrimaryContactPersonDto cPCPDetails = new ClientPrimaryContactPersonDto();
           
            if (Request.IsAjaxRequest())
            {
                cPCPDetails.Title = GetValueFromRequestParams("Title");
                cPCPDetails.Gender = GetValueFromRequestParams("Gender");
                cPCPDetails.MothersMaidenName = GetValueFromRequestParams("MothersMaidenName");
                cPCPDetails.DateOfBirth = ConvertStringToDate(GetValueFromRequestParams("DateOfBirth"));
                cPCPDetails.PAN = GetValueFromRequestParams("PAN");
                cPCPDetails.UID = GetValueFromRequestParams("UID");
                cPCPDetails.CAPrimaryConatactPersonName = GetValueFromRequestParams("CLRPCPName");
                cPCPDetails.IsSameAsCompanyAddress = GetBoolValueFromRequestParams("IsSameAsCompanyAddress");
                cPCPDetails.IsSameAsCompanyContact = GetBoolValueFromRequestParams("IsSameAsCompanyContact");

                cPCPDetails.ClientPrimaryContactPersonDesignation = new DesignationDto
                {
                    DesignationId = GetIntValueFromRequestParams("DesignationId")
                };
                cPCPDetails.ClientPrimaryContactPersonAddress = new Common.Dto.Address.AddressDto
                {
                    AddressLine1 = GetValueFromRequestParams("AddressLine1")
                };
                int cityVillageId = (Request.Params["CityVillageId"]) != null ? Convert.ToInt32(Request.Params["CityVillageId"]) : 0;
                if (cityVillageId != 0)
                {
                    CityVillageServiceReference.CityVillageServiceClient cityVillageServiceClient = new CityVillageServiceClient();
                    CityVillageDto cityVillageDto = cityVillageServiceClient.GetById(cityVillageId);
                    cPCPDetails.ClientPrimaryContactPersonAddress.CityVillage = cityVillageDto;
                }
                cPCPDetails.ClientPrimaryContactPersonAddress.PIN = GetValueFromRequestParams("PIN");
                cPCPDetails.Email1 = GetValueFromRequestParams("Email1");
                cPCPDetails.Email2 = GetValueFromRequestParams("Email2");
                cPCPDetails.ClientPrimaryContacts = GetContactsFromString(Request.Params["contactDetails"]);
            }
            else
            {
                cPCPDetails.Title = clientRegistrationModel.ClientPrimaryContactPerson.Title;
                cPCPDetails.Gender = clientRegistrationModel.ClientPrimaryContactPerson.Gender;
                cPCPDetails.MothersMaidenName = clientRegistrationModel.ClientPrimaryContactPerson.MothersMaidenName;
                cPCPDetails.DateOfBirth = clientRegistrationModel.ClientPrimaryContactPerson.DateOfBirth;
                cPCPDetails.PAN = clientRegistrationModel.ClientPrimaryContactPerson.PAN;
                cPCPDetails.UID = clientRegistrationModel.ClientPrimaryContactPerson.UID;
                cPCPDetails.CAPrimaryConatactPersonName = clientRegistrationModel.ClientPrimaryContactPerson.CAPrimaryConatactPersonName;
                cPCPDetails.IsSameAsCompanyAddress = clientRegistrationModel.ClientPrimaryContactPerson.IsSameAsCompanyAddress;
                cPCPDetails.IsSameAsCompanyContact = clientRegistrationModel.ClientPrimaryContactPerson.IsSameAsCompanyContact;

                if (ComboBoxExtension.GetValue<object>(clientRegistrationModel.designationModel[0].DDLDesignations) != null)
                {
                    cPCPDetails.ClientPrimaryContactPersonDesignation = new DesignationDto
                    {
                        DesignationId = ComboBoxExtension.GetValue<int>(clientRegistrationModel.designationModel[0].DDLDesignations)
                    };
                }

                cPCPDetails.ClientPrimaryContactPersonAddress = new Common.Dto.Address.AddressDto
                {
                    AddressLine1 = clientRegistrationModel.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.AddressLine1
                };
                int cityVillageId = clientRegistrationModel.StateDistrictPlacesControlNames[1].HiddenFieldForCityVillageValue;
                if (cityVillageId != 0)
                {
                    CityVillageServiceReference.CityVillageServiceClient cityVillageServiceClient = new CityVillageServiceClient();
                    CityVillageDto cityVillageDto = cityVillageServiceClient.GetById(cityVillageId);
                    cPCPDetails.ClientPrimaryContactPersonAddress.CityVillage = cityVillageDto;
                }
                cPCPDetails.ClientPrimaryContactPersonAddress.PIN = clientRegistrationModel.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.PIN;
                cPCPDetails.Email1 = clientRegistrationModel.ClientPrimaryContactPerson.Email1;
                cPCPDetails.Email2 = clientRegistrationModel.ClientPrimaryContactPerson.Email2;
                cPCPDetails.ClientPrimaryContacts = clientRegistrationModel.ClientPrimaryContactPerson.ClientPrimaryContacts;
            }
            companyProfile.ClientPrimaryContactPerson = cPCPDetails;
            if (Session["PrimaryContactPersonUploadedImageFileName"] != null)
            {
                companyProfile.ClientPrimaryContactPerson.Image = Session["PrimaryContactPersonUploadedImageFileName"].ToString();
            }
            Session["CompanyProfile"] = companyProfile;
        }

        public DateTime ConvertStringToDate(string newDate)
        {
            string sDate = newDate;
            DateTime date = new DateTime();

            if (!String.IsNullOrEmpty(sDate))
            {
                string[] sDOB = sDate.Split('-');
                date = new DateTime(Convert.ToInt32(sDOB[2]), Convert.ToInt32(sDOB[1]), Convert.ToInt32(sDOB[0]));
            }
            return date;
        }

        public void SaveAPMCDetails(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");
            companyProfile.APMCLicenseNo = GetValueFromRequestParams("APMCLicenseNo"); ;
            companyProfile.APMCLicenseValidUpTo = ConvertStringToDate(GetValueFromRequestParams("APMCLicenseValidUpToDate"));
            int apmcId = 0;
            string sSelectedCommodityClassIdList = "";
            if (Request.IsAjaxRequest())
            {
                apmcId = GetIntValueFromRequestParams("APMCId");
                sSelectedCommodityClassIdList = GetValueFromRequestParams("SelectedCommodityClassIdList").TrimEnd(';');
                companyProfile.HiddenFieldForAPMCValue = apmcId;
            }
            else
            {
                apmcId=GetIntValueFromRequestParams("APMCId");
                int hdnCommodityClassCount = GetIntValueFromRequestParams("hdnCommodityClassCount");
                for (int i = 0; i < hdnCommodityClassCount; i++)
                {
                    if (Convert.ToBoolean(GetValueFromRequestParams("CommodityClassDtoList[" + i+"].IsActive").Split(',')[0]))
                    {
                        sSelectedCommodityClassIdList += GetValueFromRequestParams("hdnCommodityClassId" + i) + ";";
                    }
                }
                sSelectedCommodityClassIdList = sSelectedCommodityClassIdList.TrimEnd(';');
                companyProfile.HiddenFieldForAPMCValue = Convert.ToInt32(GetValueFromRequestParams("HiddenFieldForAPMCValue"));
                apmcId = companyProfile.HiddenFieldForAPMCValue;
            }

            companyProfile.ClientAPMC = new APMCDto
            {
                APMCId = apmcId
            };

            IList<CommodityClassDto> commodityClassList = new List<CommodityClassDto>();
            
            if (!String.IsNullOrEmpty(sSelectedCommodityClassIdList))
            {
                foreach (string sCommodityClassId in sSelectedCommodityClassIdList.Split(';'))
                {
                    commodityClassList.Add(new CommodityClassDto
                    {
                        CommodityClassId = Convert.ToInt32(sCommodityClassId)
                    });
                }
            }

            companyProfile.ClientCommodities = commodityClassList;
            Session["CompanyProfile"] = companyProfile;
        }

        public void SaveBusinessConstitution(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");
            if (Request.IsAjaxRequest())
            {
                companyProfile.ClientBusinessConstitution.BusinessConstitutionId = GetIntValueFromRequestParams("BussinessConstitutionId");
                companyProfile.NoOfPartners = GetIntValueFromRequestParams("NoOfClientPartners");
            }
            else
            {
                companyProfile.ClientBusinessConstitution.BusinessConstitutionId = GetIntValueFromRequestParams("cmbBusinessContitutions_VI");
                companyProfile.NoOfPartners = GetIntValueFromRequestParams("businessConstitutionModel.NoOfClientPartners"); 
            }

            
            
            if (Session["BusinessConstitution"] == null)
            {
                Session["BusinessConstitution"] = new BusinessConstitutionModel();
            }
            BusinessConstitutionModel BCModel = new BusinessConstitutionModel();
            BCModel.SelectedIndex = companyProfile.ClientBusinessConstitution.BusinessConstitutionId;
            BCModel.NoOfClientPartners = companyProfile.NoOfPartners;
            if (Session["ClientPartners"] != null)
            {
                companyProfile.ClientPartners = (List<ClientPartnerDetailsDto>)Session["ClientPartners"];
                BCModel.ClientPartners = companyProfile.ClientPartners.ToList();
            }
            Session["BusinessConstitution"] = BCModel;
            companyProfile.businessConstitutionModel = (BusinessConstitutionModel)Session["BusinessConstitution"];
            Session["CompanyProfile"] = companyProfile;
        }

        public void SaveSubscriptionDetails(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");
            //SelectedPackage
            companyProfile.ClientSubscription.AllowEdit = true;
            if (companyProfile.ClientSubscription == null)
                companyProfile.ClientSubscription = new ClientSubscriptionDto();
            if (companyProfile.ClientSubscription.SubscriptionMaster == null)
                    companyProfile.ClientSubscription.SubscriptionMaster = new SubscriptionMasterDto();
            if(Request.IsAjaxRequest())
            {
                companyProfile.ClientSubscription.SubscriptionMaster.SubscriptionId = GetIntValueFromRequestParams("SelectedPackageId");
                companyProfile.ClientSubscription.ActivationDate = ConvertStringToDate(GetValueFromRequestParams("ActivationDate"));
                companyProfile.ClientSubscription.AdditionalCostForAssociates = GetDecimalValueFromRequestParams("AssociateCost");
                companyProfile.ClientSubscription.AdditionalCostForAuditors = GetDecimalValueFromRequestParams("AuditorCost");
                companyProfile.ClientSubscription.AdditionalCostForEmployees = GetDecimalValueFromRequestParams("EmployeeCost");
                companyProfile.ClientSubscription.AdditionalNoOfAssociates = GetIntValueFromRequestParams("NoOfAssociates");
                companyProfile.ClientSubscription.AdditionalNoOfAuditors = GetIntValueFromRequestParams("NoOfAuditors");
                companyProfile.ClientSubscription.AdditionalNoOfEmployees = GetIntValueFromRequestParams("NoOfEmployees");
                companyProfile.ClientSubscription.DiscountInPercentage = GetFloatValueFromRequestParams("DiscountInPercentage");
                companyProfile.ClientSubscription.DiscountInRupees = GetDecimalValueFromRequestParams("DiscountInRupees");
                companyProfile.ClientSubscription.SubscriptionPeriod = GetIntValueFromRequestParams("Period");
                companyProfile.ClientSubscription.SubscriptionPeriodFromDate = ConvertStringToDate(GetValueFromRequestParams("SubscriptionPeriodFromDate"));
                companyProfile.ClientSubscription.SubscriptionPeriodToDate = ConvertStringToDate(GetValueFromRequestParams("SubscriptionPeriodToDate"));
                companyProfile.ClientSubscription.AdditionalInfo = GetValueFromRequestParams("AdditionalInfo");
                companyProfile.ClientSubscription.ServiceTax = GetDecimalValueFromRequestParams("ServiceTax");
                companyProfile.ClientSubscription.OtherTax = GetDecimalValueFromRequestParams("ServiceTax");
            }
            else
            {
                companyProfile.ClientSubscription.SubscriptionMaster.SubscriptionId = clientRegistrationModel.ClientSubscription.SubscriptionMaster.SubscriptionId;
                companyProfile.ClientSubscription.ActivationDate = clientRegistrationModel.ClientSubscription.ActivationDate;
                companyProfile.ClientSubscription.AdditionalCostForAssociates = clientRegistrationModel.ClientSubscription.AdditionalCostForAssociates;
                companyProfile.ClientSubscription.AdditionalCostForAuditors = clientRegistrationModel.ClientSubscription.AdditionalCostForAuditors;
                companyProfile.ClientSubscription.AdditionalCostForEmployees = clientRegistrationModel.ClientSubscription.AdditionalCostForEmployees;
                companyProfile.ClientSubscription.AdditionalNoOfAssociates = clientRegistrationModel.ClientSubscription.AdditionalNoOfAssociates;
                companyProfile.ClientSubscription.AdditionalNoOfAuditors = clientRegistrationModel.ClientSubscription.AdditionalNoOfAuditors;
                companyProfile.ClientSubscription.AdditionalNoOfEmployees = clientRegistrationModel.ClientSubscription.AdditionalNoOfEmployees;
                companyProfile.ClientSubscription.DiscountInPercentage = clientRegistrationModel.ClientSubscription.DiscountInPercentage;
                companyProfile.ClientSubscription.DiscountInRupees = clientRegistrationModel.ClientSubscription.DiscountInRupees;
                companyProfile.ClientSubscription.SubscriptionPeriod = clientRegistrationModel.ClientSubscription.SubscriptionPeriod;
                companyProfile.ClientSubscription.SubscriptionPeriodFromDate = clientRegistrationModel.ClientSubscription.SubscriptionPeriodFromDate;
                companyProfile.ClientSubscription.SubscriptionPeriodToDate = clientRegistrationModel.ClientSubscription.SubscriptionPeriodToDate;
                companyProfile.ClientSubscription.AdditionalInfo = clientRegistrationModel.ClientSubscription.AdditionalInfo;
                companyProfile.ClientSubscription.ServiceTax = clientRegistrationModel.ClientSubscription.ServiceTax;
                companyProfile.ClientSubscription.OtherTax = clientRegistrationModel.ClientSubscription.OtherTax;
                companyProfile.ClientSubscription.NetAmount = clientRegistrationModel.NetAmount;

            }

            Session["CompanyProfile"] = companyProfile;
        }

        public void SavePaymentDetails(int currentIndex, string additionalInfo, decimal tds)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");            
            companyProfile.AdditionalInfoForSubscriptionPayment = additionalInfo;
            companyProfile.TDSOnSubscriptionPayment = tds;
            Session["CompanyProfile"] = companyProfile;
        }

        public void SaveAccountmanager(long AccountManagerId)
        {
            ClientRegistrationModel companyProfile = GetClientModelFromSession();
            Session["ClientRegistrationActiveTab"] = GetValueFromRequestParams("currentIndex");
            if (Request.IsAjaxRequest())
                companyProfile.AccountManagerId = Convert.ToInt64(GetValueFromRequestParams("AccountManagerId"));
            else
                companyProfile.AccountManagerId = AccountManagerId;
            Session["CompanyProfile"] = companyProfile;
        }

        public int GetIntValueFromRequestParams(string paramater)
        {
            return Request.Params[paramater] != null ? Convert.ToInt32(Request.Params[paramater]) : 0;
        }

        public decimal GetDecimalValueFromRequestParams(string paramater)
        {
            return Request.Params[paramater] != null ? Convert.ToDecimal(Request.Params[paramater]) : 0;
        }

        public float GetFloatValueFromRequestParams(string paramater)
        {
            return Request.Params[paramater] != null ? float.Parse(Request.Params[paramater]) : 0;
        }

        public string GetValueFromRequestParams(string paramater)
        {
            return Request.Params[paramater] != null ? Request.Params[paramater] : "";
        }

        public bool GetBoolValueFromRequestParams(string paramater)
        {
            return Request.Params[paramater] != null ? Convert.ToBoolean(Request.Params[paramater]) : false;
        }

        public IList<ContactDetailsDto> GetContactsFromString(string contactDetails)
        {
            IList<ContactDetailsDto> contacts = new List<ContactDetailsDto>();
            if (!String.IsNullOrEmpty(contactDetails))
            {
                contactDetails = contactDetails.TrimEnd(';');
                foreach (string contactDetail in contactDetails.Split(';'))
                {
                    string[] ContactDetail = contactDetail.Split(',');
                    ContactDetailsDto contact = new ContactDetailsDto
                    {
                        ContactNoType = GetContactType(ContactDetail[0]),
                        STDCode = ContactDetail[1],
                        ContactNo = ContactDetail[2]
                    };
                    contacts.Add(contact);
                }
            }
            return contacts;
        }

        public ContactType GetContactType(string type)
        {
            ContactType result = ContactType.MobileNo;
            switch (type)
            {
                case "MobileNo": result = ContactType.MobileNo;
                    break;
                case "Fax": result = ContactType.Fax;
                    break;
                case "OfficeNo": result = ContactType.OfficeNo;
                    break;
                case "ResidenceNo": result = ContactType.ResidenceNo;
                    break;

            }
            return result;
        }
        #endregion
    }
}

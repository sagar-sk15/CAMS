using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common.Message;
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
using Cams.Common.Querying;
using Cams.Web.MVCRazor.BusinessConstitutionServiceReference;
using Cams.Web.MVCRazor.CityVillageServiceReference;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class ClientAccountController : CommonController
    {
        //string mode = string.Empty;
        private bool hasWarnings = true;
        private bool isModelStateValid;
        private ClientRegistrationModel modelClientRegistration;

        #region Client Welcome Page
        [CamsAuthorize(Roles = Constants.MANAGECLIENTUSERS, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult ClientWelcome()
        {
            return View("ClientWelcome");
        }
        #endregion

        #region Clients List
        public ActionResult ClientsIndex()
        {
            ClientsModel model = new ClientsModel();
            model.Clients = GetClientList();
            return View("Clients", model);
        }

        public ActionResult GetClients()
        {
            return PartialView("ClientsGridView", GetClientList());
        }

        public List<ClientDto> GetClientList()
        {
            Query query = new Query();
            ClientServiceReference.ClientServiceClient client = new ClientServiceReference.ClientServiceClient();
            var Clients = client.FindByQuery(query, true);
            client.Close();
            return Clients.Entities.ToList();
        }
        #endregion

        #region Client Registration
        [CamsAuthorize(Roles = Constants.CLIENTREGISTRATION, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult ClientRegistrationPageLoad()
        {
            ClientRegistrationModel model = new ClientRegistrationModel();
            model.hdnCurrentTab = 0;
            RemoveClientRegistrationSessions();
            Session["ClientSubscriptionPaymentDetailsModel"] = model.ClientSubscriptionPaymentDetailsModel;
            return View("CompanyProfile", model);
        }

        #region EditClientIndex
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERS + "," + Constants.MANAGECLIENTUSERS
            , Permissions = CamsAuthorizeAttribute.RolePermission.Update)]
        public ActionResult EditClientIndex()
        {
            ClientRegistrationModel model = new ClientRegistrationModel();
            RemoveClientRegistrationSessions();

            if (Request.QueryString["mode"] != null)
            {
                model.mode = Request.QueryString["mode"].ToString();
            }
            int CAId = 0;
            if (Request.QueryString["caid"] != null)
            {
                CAId = Convert.ToInt32(Request.QueryString["caid"].ToString());
            }

            ClientServiceClient client = null;
            ClientDto clientdto = null;

            try
            {
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                if (CAId > 0)
                {
                    client = new ClientServiceClient();
                    clientdto = client.GetById(CAId);
                    if (clientdto != null && clientdto.AllowEdit)
                    {
                        #region Client Registration
                        // Session["ClientSubscriptionPaymentDetailsModel"] = null;

                        #region CompanyProfile
                        model.DisplayClientId = clientdto.DisplayClientId;
                        model.CompanyName = clientdto.CompanyName;
                        if (clientdto.IsActive && clientdto.RegistrationDate != null)
                        {
                            model.RegistrationDate = clientdto.RegistrationDate;
                        }
                        else
                        {
                            model.RegistrationDate = null;
                        }
                        model.Alias = clientdto.Alias;
                        model.PAN = clientdto.PAN;
                        model.TAN = clientdto.TAN;
                        model.Image = clientdto.Image;
                        model.Email1 = clientdto.Email1;
                        model.Email2 = clientdto.Email2;
                        model.Website = clientdto.Website;
                        model.IsActive = clientdto.IsActive;
                        model.IsDeleted = clientdto.IsDeleted;
                        model.Status = clientdto.Status;
                        model.AllowEdit = true;
                        model.APMCLicenseNo = clientdto.APMCLicenseNo;
                        model.APMCLicenseValidUpTo = clientdto.APMCLicenseValidUpTo;
                        model.NoOfPartners = clientdto.NoOfPartners;
                        model.TDSOnSubscriptionPayment = clientdto.TDSOnSubscriptionPayment;
                        model.AdditionalInfoForSubscriptionPayment = clientdto.AdditionalInfoForSubscriptionPayment;

                        model.CreatedBy = CurrentUser.UserId;
                        model.ModifiedBy = CurrentUser.UserId;
                        model.CreatedDate = DateTime.Now;
                        model.ModifiedDate = DateTime.Now;
                        #endregion

                        #region Company Profile Address & Contact
                        if (clientdto.ClientContacts != null)
                        {
                            model.ClientContacts = clientdto.ClientContacts;
                        }
                        if (clientdto.ClientAddress != null)
                        {
                            model.ClientAddress = clientdto.ClientAddress;
                            if (clientdto.ClientAddress.CityVillage != null)
                            {
                                model.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue = clientdto.ClientAddress.CityVillage.CityVillageId;
                                model.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue = clientdto.ClientAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                                model.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue = clientdto.ClientAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                            }
                        }
                        #endregion

                        #region Client PrimaryContactPerson
                        if (clientdto.ClientPrimaryContactPerson != null)
                        {
                            model.ClientPrimaryContactPerson = clientdto.ClientPrimaryContactPerson;
                            if (clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
                            {
                                model.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress = clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress;
                                if (clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage != null)
                                {
                                    model.StateDistrictPlacesControlNames[1].HiddenFieldForCityVillageValue = clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage.CityVillageId;
                                    model.StateDistrictPlacesControlNames[1].HiddenFieldForDistrictValue = clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                                    model.StateDistrictPlacesControlNames[1].HiddenFieldForStateValue = clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                                }
                            }
                            if (clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation != null)
                            {
                                model.designationModel[0].SelectedId = clientdto.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation.DesignationId;
                            }
                            model.dOBnAgeModellist[0].BindDate = clientdto.ClientPrimaryContactPerson.DateOfBirth != null ? Convert.ToDateTime(clientdto.ClientPrimaryContactPerson.DateOfBirth) : Helper.SetDefaultDate();
                        }
                        #endregion

                        #region Client APMC & Commodity Class
                        if (clientdto.ClientAPMC != null)
                        {
                            model.ClientAPMC = clientdto.ClientAPMC;
                            model.APMCId = clientdto.ClientAPMC.APMCId;
                            model.HiddenFieldForAPMCValue = model.APMCId;
                        }
                        if (clientdto.ClientCommodities != null)
                        {
                            model.ClientCommodities = clientdto.ClientCommodities;
                            model.CommodityClassDtoList.Where(dir1 => clientdto.ClientCommodities.Any(dir2 => dir2.CommodityClassId == dir1.CommodityClassId)).ToList().Update(e => e.IsActive = true);
                        }
                        #endregion

                        #region Client BusinessConstitution
                        if (clientdto.ClientBusinessConstitution != null)
                        {
                            model.ClientBusinessConstitution = clientdto.ClientBusinessConstitution;
                            model.businessConstitutionModel.BusinessConstitutionId = clientdto.ClientBusinessConstitution.BusinessConstitutionId;
                            model.businessConstitutionModel.SelectedIndex = BusinessConstitutionModel.GetBusinessConstitution().FindIndex(x => x.BusinessConstitutionId == model.businessConstitutionModel.BusinessConstitutionId);
                            if (clientdto.ClientBusinessConstitution.BusinessConstitutionName.Contains("Sole"))
                            {
                                model.businessConstitutionModel.NoOfClientPartners = 1;
                            }
                            else
                            {
                                if (clientdto.ClientPartners != null)
                                {
                                    if (clientdto.ClientPartners.Count > 2)
                                    {
                                        model.businessConstitutionModel.NoOfClientPartners = clientdto.ClientPartners.Count;
                                    }
                                    else
                                    {
                                        model.businessConstitutionModel.NoOfClientPartners = 2;
                                    }
                                }
                            }
                            model.businessConstitutionModel.NoOfClientPartnersAdded = clientdto.ClientPartners != null ? clientdto.ClientPartners.Count : 0;
                            Session["BusinessConstitution"] = model.businessConstitutionModel;
                        }
                        if (clientdto.ClientPartners != null && clientdto.ClientPartners.Count > 0)
                        {
                            model.ClientPartners = clientdto.ClientPartners;
                            model.ClientPartners.Update(x => x.ClientPartnerContacts = x.ClientPartnerContacts.ToList());
                            model.businessConstitutionModel.ClientPartners = clientdto.ClientPartners.ToList();
                            Session["ClientPartners"] = model.ClientPartners.ToList();
                        }
                        #endregion

                        #region Client Subscription
                        if (clientdto.ClientSubscription != null)
                        {
                            model.ClientSubscription = clientdto.ClientSubscription;
                        }
                        #endregion

                        #region ClientSubscription Payment

                        if (clientdto.ClientSubscription != null)
                        {
                            if (clientdto.ClientSubscription.ClientSubscriptionPaymentDetails != null && clientdto.ClientSubscription.ClientSubscriptionPaymentDetails.Count > 0)
                            {
                                decimal totalAmount = 0;
                                foreach (var clientSubscriptionPaymentDetailsDto in clientdto.ClientSubscription.ClientSubscriptionPaymentDetails)
                                {
                                    ClientSubscriptionPaymentDetailsModel clientSubscriptionPaymentDetailsModel = new ClientSubscriptionPaymentDetailsModel();
                                    clientSubscriptionPaymentDetailsModel.PaymentMode =
                                        clientSubscriptionPaymentDetailsDto.PaymentMode;
                                    #region For Cash
                                    if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.Cash)
                                    {
                                        if (clientSubscriptionPaymentDetailsDto.Amount != 0)
                                        {
                                            clientSubscriptionPaymentDetailsModel.CashAmount =
                                        clientSubscriptionPaymentDetailsDto.Amount;

                                        }
                                    }
                                    #endregion

                                    if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.Cheque)
                                    {
                                        clientSubscriptionPaymentDetailsModel.ChequeAmount =
                                            clientSubscriptionPaymentDetailsDto.Amount;
                                        clientSubscriptionPaymentDetailsModel.HiddenFieldForChequeBankBranch =
                                                clientSubscriptionPaymentDetailsDto.BankBranch.BranchId;
                                    }
                                    if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.Online)
                                    {
                                        clientSubscriptionPaymentDetailsModel.OnlineAmount =
                                            clientSubscriptionPaymentDetailsDto.Amount;
                                        clientSubscriptionPaymentDetailsModel.HiddenFieldForOnlineBankBranch =
                                               clientSubscriptionPaymentDetailsDto.BankBranch.BranchId;
                                    }
                                    if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.DD)
                                    {
                                        clientSubscriptionPaymentDetailsModel.DDAmount =
                                            clientSubscriptionPaymentDetailsDto.Amount;
                                        clientSubscriptionPaymentDetailsModel.HiddenFieldForDDBankBranch =
                                               clientSubscriptionPaymentDetailsDto.BankBranch.BranchId;
                                    }
                                    clientSubscriptionPaymentDetailsModel.ChequeDDTransactionDate =
                                        clientSubscriptionPaymentDetailsDto.ChequeDDTransactionDate;

                                    clientSubscriptionPaymentDetailsModel.ChequeDDTransationNo =
                                        clientSubscriptionPaymentDetailsDto.ChequeDDTransationNo;

                                    clientSubscriptionPaymentDetailsModel.ChequeDDClearanceDates =
                                        clientSubscriptionPaymentDetailsDto.ChequeDDClearanceDates;

                                    clientSubscriptionPaymentDetailsModel.IsRTGS =
                                        clientSubscriptionPaymentDetailsDto.IsRTGS;

                                    clientSubscriptionPaymentDetailsModel.IsStandardCheque =
                                        clientSubscriptionPaymentDetailsDto.IsStandardCheque;

                                    clientSubscriptionPaymentDetailsModel.IsNEFT =
                                        clientSubscriptionPaymentDetailsDto.IsNEFT;

                                    clientSubscriptionPaymentDetailsModel.BankBranch =
                                        clientSubscriptionPaymentDetailsDto.BankBranch;

                                    totalAmount += clientSubscriptionPaymentDetailsDto.Amount;

                                    if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.Cash && model.ClientSubscriptionPaymentDetailsModel[0].CashAmount == 0)
                                    {
                                        model.ClientSubscriptionPaymentDetailsModel.RemoveAt(0);
                                        model.ClientSubscriptionPaymentDetailsModel.Insert(0, clientSubscriptionPaymentDetailsModel);
                                    }
                                    else if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.Cheque && model.ClientSubscriptionPaymentDetailsModel[1].ChequeAmount == 0)
                                    {
                                        model.ClientSubscriptionPaymentDetailsModel.RemoveAt(1);
                                        model.ClientSubscriptionPaymentDetailsModel.Insert(1, clientSubscriptionPaymentDetailsModel);
                                    }
                                    else if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.Online && model.ClientSubscriptionPaymentDetailsModel[2].OnlineAmount == 0)
                                    {
                                        model.ClientSubscriptionPaymentDetailsModel.RemoveAt(2);
                                        model.ClientSubscriptionPaymentDetailsModel.Insert(2, clientSubscriptionPaymentDetailsModel);
                                    }
                                    else if (clientSubscriptionPaymentDetailsModel.PaymentMode == PaymentMode.DD && model.ClientSubscriptionPaymentDetailsModel[3].DDAmount == 0)
                                    {
                                        model.ClientSubscriptionPaymentDetailsModel.RemoveAt(3);
                                        model.ClientSubscriptionPaymentDetailsModel.Insert(3, clientSubscriptionPaymentDetailsModel);
                                    }
                                    else
                                    {
                                        model.ClientSubscriptionPaymentDetailsModel.Add(clientSubscriptionPaymentDetailsModel);
                                    }
                                }

                                if (model.ClientSubscriptionPaymentDetailsModel != null && model.ClientSubscriptionPaymentDetailsModel.Count > 0)
                                {
                                    model.ClientSubscriptionPaymentDetailsModel[0].TotalAmount =
                                        totalAmount;
                                    model.ClientSubscriptionPaymentDetailsModel[0].TDS =
                                        clientdto.TDSOnSubscriptionPayment;
                                    model.ClientSubscriptionPaymentDetailsModel[0].NetAmount =
                                        model.ClientSubscriptionPaymentDetailsModel[0].TotalAmount -
                                        model.ClientSubscriptionPaymentDetailsModel[0].TDS;
                                    model.ClientSubscriptionPaymentDetailsModel[0].AdditionalInfo =
                                        clientdto.AdditionalInfoForSubscriptionPayment;
                                }
                            }
                            Session["ClientSubscriptionPaymentDetailsModel"] = model.ClientSubscriptionPaymentDetailsModel;
                        }
                        #endregion

                        #region Client AccountManager
                        model.AccountManagerId = clientdto.AccountManagerId;
                        #endregion

                        #endregion
                    }
                }
                Session["CompanyProfile"] = model;
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
            return View("CompanyProfile", model);
        }
        #endregion

        #region ClientRegistrationIndex
        [CamsAuthorize(Roles = Constants.CLIENTREGISTRATION, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult ClientRegistrationIndex()
        {
            ClientRegistrationModel model = GetClientModelFromSession();
            if (Request.QueryString["mode"] != null)
            {
                model.mode = Request.QueryString["mode"].ToString();
            }
            

            model.hdnCurrentTab = Session["ClientRegistrationActiveTab"] != null ? Convert.ToInt32(Session["ClientRegistrationActiveTab"]) : 0;

            #region Company Profile Address
            if (model.ClientAddress != null)
            {
                if (model.ClientAddress.CityVillage != null)
                {
                    model.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue = model.ClientAddress.CityVillage.CityVillageId;
                    model.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue = model.ClientAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                    model.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue = model.ClientAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                }

            }
            #endregion

            #region Client PrimaryContactPerson
            if (model.ClientPrimaryContactPerson != null)
            {
                if (model.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
                {
                    if (model.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage != null)
                    {
                        model.StateDistrictPlacesControlNames[1].HiddenFieldForCityVillageValue =
                            model.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage.CityVillageId;
                        model.StateDistrictPlacesControlNames[1].HiddenFieldForDistrictValue =
                            model.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                        model.StateDistrictPlacesControlNames[1].HiddenFieldForStateValue =
                            model.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                    }
                }
                if (model.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation != null)
                {
                    model.designationModel[0].SelectedId =
                        model.ClientPrimaryContactPerson.ClientPrimaryContactPersonDesignation.DesignationId;
                }
                model.dOBnAgeModellist[0].BindDate =
                    model.ClientPrimaryContactPerson.DateOfBirth != null ?
                    Convert.ToDateTime(model.ClientPrimaryContactPerson.DateOfBirth) :
                    Helper.SetDefaultDate();
            }
            #endregion

            #region Client APMC & Commodity Class
            if (model.ClientAPMC != null)
            {
                model.HiddenFieldForAPMCValue = model.ClientAPMC.APMCId;
            }
            if (model.ClientCommodities != null)
            {
                model.CommodityClassDtoList.Where(dir1 => model.ClientCommodities.Any(dir2 => dir2.CommodityClassId == dir1.CommodityClassId)).ToList().Update(e => e.IsActive = true);
            }
            #endregion

            #region Business Constitution
            model = SetBusinessConstitution(model);
            #endregion

            #region Client Subscription Payment Details
            Session["ClientSubscriptionPaymentDetailsModel"] = model.ClientSubscriptionPaymentDetailsModel;
            #endregion

            return View("CompanyProfile", model);
        }
        #endregion

        #region ClientRegistration
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Save")]
        public ActionResult ClientRegistration(ClientRegistrationModel clientRegistrationModel, string saveMode = null)
        {
            ClientServiceReference.ClientServiceClient clientService = null;
            ClientRegistrationModel model = new ClientRegistrationModel();
            string action = string.Empty;
            try
            {
                ViewData["Error"] = null;
                TempData["Success"] = null;

                if (!string.IsNullOrEmpty(Request.QueryString["mode"]))
                {
                    model.mode = Request.QueryString["mode"];
                }
                Nullable<int> Caid = null;
                if (!string.IsNullOrEmpty(Request.QueryString["caid"]))
                {
                    Caid = Convert.ToInt32(Request.QueryString["caid"]);
                }

                #region Set DevExpress Controls to retain state on postback

                if (ComboBoxExtension.GetValue<object>("cmbAccountManager") != null)
                {
                    model.AccountManagerId = ComboBoxExtension.GetValue<int>("cmbAccountManager");
                    clientRegistrationModel.AccountManagerId = model.AccountManagerId;
                }

                foreach (StateDistrictCityControlNamesModel controlName in clientRegistrationModel.StateDistrictPlacesControlNames)
                {
                    controlName.HiddenFieldForCityVillageValue =
                        !String.IsNullOrEmpty(Request.Params[controlName.PlacesComboName + "_VI"]) ?
                        Convert.ToInt32(Request.Params[controlName.PlacesComboName + "_VI"]) : 0;
                    controlName.HiddenFieldForDistrictValue =
                        !String.IsNullOrEmpty(Request.Params[controlName.DistrictComboName + "_VI"]) ?
                        Convert.ToInt32(Request.Params[controlName.DistrictComboName + "_VI"]) : 0;
                    controlName.HiddenFieldForStateValue =
                        !String.IsNullOrEmpty(Request.Params[controlName.StateComboName + "_VI"]) ?
                        Convert.ToInt32(Request.Params[controlName.StateComboName + "_VI"]) : 0;
                }

                if (EditorExtension.GetValue<object>(clientRegistrationModel.dOBnAgeModellist[0].txtDOBnAgeName) != null)
                {
                    clientRegistrationModel.ClientPrimaryContactPerson.DateOfBirth = EditorExtension.GetValue<DateTime>(clientRegistrationModel.dOBnAgeModellist[0].txtDOBnAgeName);
                }
                #endregion

                #region Get model from session
                UpdateSessionForCurrentTab(GetValueFromRequestParams("hdnCurrentTab"), clientRegistrationModel);
                model = GetClientModelFromSession();
                model.ClientSubscriptionPaymentDetailsModel = (IList<ClientSubscriptionPaymentDetailsModel>)Session["ClientSubscriptionPaymentDetailsModel"];
                model.ClientPartners = (List<ClientPartnerDetailsDto>)Session["ClientPartners"];
                #endregion

                #region Check for basic validations
                CheckForValidation(model);
                #endregion

                #region Assign required properties
                model.IsCashChecked = clientRegistrationModel.IsCashChecked;
                model.IsChequeChecked = clientRegistrationModel.IsChequeChecked;
                model.IsOnlineChecked = clientRegistrationModel.IsOnlineChecked;
                model.IsDDChecked = clientRegistrationModel.IsDDChecked;

                #endregion

                clientRegistrationModel = model;

                #region If Model is valid invoke save else set failure message

                isModelStateValid = ModelState.IsValid;

                if (ModelState.IsValid)
                {
                    clientService = new ClientServiceClient();
                    UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                    ClientDto NewClientDto = new ClientDto();

                    if (Caid != null)
                    {
                        NewClientDto = clientService.GetById(Convert.ToInt32(Caid));
                    }

                    #region Client Registration
                    // Session["ClientSubscriptionPaymentDetailsModel"] = null;

                    #region CompanyProfile
                    NewClientDto.DisplayClientId = "";
                    NewClientDto.CompanyName = model.CompanyName;
                    NewClientDto.RegistrationDate = model.RegistrationDate;
                    NewClientDto.Alias = model.Alias;
                    NewClientDto.PAN = model.PAN;
                    NewClientDto.TAN = model.TAN;
                    NewClientDto.Email1 = model.Email1;
                    NewClientDto.Email2 = model.Email2;
                    NewClientDto.Website = model.Website;
                    NewClientDto.IsActive = model.IsActive;
                    NewClientDto.IsDeleted = model.IsDeleted;
                    NewClientDto.Status = model.Status;
                    NewClientDto.AllowEdit = true;
                    NewClientDto.APMCLicenseNo = model.APMCLicenseNo;
                    NewClientDto.APMCLicenseValidUpTo = model.APMCLicenseValidUpTo;
                    NewClientDto.NoOfPartners = model.NoOfPartners;
                    NewClientDto.TDSOnSubscriptionPayment = model.ClientSubscriptionPaymentDetailsModel[0].TDS;
                    NewClientDto.AdditionalInfoForSubscriptionPayment = model.ClientSubscriptionPaymentDetailsModel[0].AdditionalInfo;
                    NewClientDto.ModifiedBy = CurrentUser.UserId;
                    NewClientDto.ModifiedDate = DateTime.Now;
                    #endregion

                    #region CompanyProfile Address & Contact
                    if (model.ClientContacts != null)
                    {
                        List<ContactDetailsDto> contactDetailsDto = model.ClientContacts.Where(x => x.ContactNo == null).ToList();
                        if (contactDetailsDto != null)
                        {
                            foreach (ContactDetailsDto contact in contactDetailsDto)
                            {
                                model.ClientContacts.Remove(contact);
                            }
                        }
                    }
                    NewClientDto.ClientContacts = model.ClientContacts;
                    NewClientDto.ClientAddress = model.ClientAddress;
                    #endregion

                    #region Client APMC
                    if (model.ClientAPMC != null)
                    {
                        NewClientDto.ClientAPMC = model.ClientAPMC;
                        NewClientDto.ClientAPMC.CreatedBy = CurrentUser.UserId;
                        NewClientDto.ClientAPMC.ModifiedBy = CurrentUser.UserId;
                        NewClientDto.ClientAPMC.CreatedDate = DateTime.Now;
                        NewClientDto.ClientAPMC.ModifiedDate = DateTime.Now;
                    }
                    if (model.ClientCommodities != null)
                    {
                        NewClientDto.ClientCommodities = model.ClientCommodities;
                    }
                    #endregion

                    #region Client BusinessConstitution
                    if (model.ClientBusinessConstitution != null)
                    {
                        NewClientDto.ClientBusinessConstitution = model.ClientBusinessConstitution;
                    }
                    if (model.ClientPartners != null)
                    {
                        NewClientDto.ClientPartners = model.ClientPartners;
                        for (int i = 0; i < model.ClientPartners.Count; i++)
                        {
                            NewClientDto.ClientPartners[i].CreatedBy = CurrentUser.UserId;
                            NewClientDto.ClientPartners[i].ModifiedBy = CurrentUser.UserId;
                            NewClientDto.ClientPartners[i].CreatedDate = DateTime.Now;
                            NewClientDto.ClientPartners[i].ModifiedDate = DateTime.Now;

                            if (String.IsNullOrEmpty(model.mode) && Caid == null)
                            {
                                NewClientDto.ClientPartners[i].PartnerId = 0;
                            }
                        }
                    }
                    #endregion

                    #region Client AccountManager
                    NewClientDto.AccountManagerId = model.AccountManagerId;
                    #endregion

                    #region Client PrimaryContactPerson
                    if (model.ClientPrimaryContactPerson != null)
                    {
                        NewClientDto.ClientPrimaryContactPerson = model.ClientPrimaryContactPerson;
                        NewClientDto.ClientPrimaryContactPerson.Title = "Mr.";
                        NewClientDto.ClientPrimaryContactPerson.Gender = "M";
                        NewClientDto.ClientPrimaryContactPerson.CreatedBy = CurrentUser.UserId;
                        NewClientDto.ClientPrimaryContactPerson.ModifiedBy = CurrentUser.UserId;
                        NewClientDto.ClientPrimaryContactPerson.CreatedDate = DateTime.Now;
                        NewClientDto.ClientPrimaryContactPerson.ModifiedDate = DateTime.Now;
                        if (NewClientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress != null)
                        {
                            NewClientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CreatedBy = CurrentUser.UserId;
                            NewClientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.ModifiedBy = CurrentUser.UserId;
                            NewClientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.CreatedDate = DateTime.Now;
                            NewClientDto.ClientPrimaryContactPerson.ClientPrimaryContactPersonAddress.ModifiedDate = DateTime.Now;
                        }

                        if (Session["PrimaryContactPersonUploadedImageFileName"] != null)
                        {
                            NewClientDto.ClientPrimaryContactPerson.Image = Session["PrimaryContactPersonUploadedImageFileName"].ToString();
                        }
                    }
                    #endregion

                    #region Client Subscription
                    if (model.ClientSubscription != null)
                    {
                        NewClientDto.ClientSubscription = model.ClientSubscription;
                        NewClientDto.ClientSubscription.CreatedBy = CurrentUser.UserId;
                        NewClientDto.ClientSubscription.ModifiedBy = CurrentUser.UserId;
                        NewClientDto.ClientSubscription.CreatedDate = DateTime.Now;
                        NewClientDto.ClientSubscription.ModifiedDate = DateTime.Now;
                    }
                    #endregion

                    #region Client SubscriptionPaymentDetails
                    if (model.ClientSubscriptionPaymentDetailsModel != null)
                    {
                        IList<ClientSubscriptionPaymentDetailsDto> clientSubscriptionPaymentDto = new List<ClientSubscriptionPaymentDetailsDto>();

                        foreach (ClientSubscriptionPaymentDetailsModel subscriptionPaymentModel in model.ClientSubscriptionPaymentDetailsModel)
                        {
                            #region For Cash
                            if (subscriptionPaymentModel.PaymentMode == PaymentMode.Cash && clientRegistrationModel.IsCashChecked == "true")
                            {
                                if (subscriptionPaymentModel.CashAmount != 0)
                                {
                                    clientSubscriptionPaymentDto.Add(new ClientSubscriptionPaymentDetailsDto
                                    {
                                        PaymentMode = PaymentMode.Cash,
                                        Amount = subscriptionPaymentModel.CashAmount,
                                        CreatedBy = CurrentUser.UserId,
                                        CreatedDate = DateTime.Now,
                                        ModifiedBy = CurrentUser.UserId,
                                        ModifiedDate = DateTime.Now
                                    });
                                }
                            }
                            #endregion

                            #region For Cheque
                            if (subscriptionPaymentModel.PaymentMode == PaymentMode.Cheque && clientRegistrationModel.IsChequeChecked == "true")
                            {

                                if (subscriptionPaymentModel.ChequeAmount != 0 || subscriptionPaymentModel.ChequeDDTransationNo != null
                                    || subscriptionPaymentModel.ChequeDDTransactionDate != null || subscriptionPaymentModel.ChequeDDClearanceDates != null
                                    || subscriptionPaymentModel.BankBranch.BranchId != 0)
                                {
                                    clientSubscriptionPaymentDto.Add(new ClientSubscriptionPaymentDetailsDto
                                    {
                                        PaymentMode = PaymentMode.Cheque,
                                        Amount = subscriptionPaymentModel.ChequeAmount,
                                        ChequeDDTransationNo = subscriptionPaymentModel.ChequeDDTransationNo,
                                        ChequeDDTransactionDate = subscriptionPaymentModel.ChequeDDTransactionDate,
                                        ChequeDDClearanceDates = subscriptionPaymentModel.ChequeDDClearanceDates,
                                        IsRTGS = subscriptionPaymentModel.IsRTGS,
                                        IsStandardCheque = subscriptionPaymentModel.IsStandardCheque,
                                        CreatedBy = CurrentUser.UserId,
                                        CreatedDate = DateTime.Now,
                                        ModifiedBy = CurrentUser.UserId,
                                        ModifiedDate = DateTime.Now,
                                        BankBranch = subscriptionPaymentModel.BankBranch
                                    });
                                }

                            }
                            #endregion

                            #region For DD
                            if (subscriptionPaymentModel.PaymentMode == PaymentMode.DD && clientRegistrationModel.IsDDChecked == "true")
                            {
                                if (subscriptionPaymentModel.DDAmount != 0 || subscriptionPaymentModel.ChequeDDTransationNo != null
                                    || subscriptionPaymentModel.ChequeDDTransactionDate != null || subscriptionPaymentModel.BankBranch.BranchId != 0)
                                {
                                    clientSubscriptionPaymentDto.Add(new ClientSubscriptionPaymentDetailsDto
                                    {
                                        PaymentMode = PaymentMode.DD,
                                        Amount = subscriptionPaymentModel.DDAmount,
                                        ChequeDDTransationNo = subscriptionPaymentModel.ChequeDDTransationNo,
                                        ChequeDDTransactionDate = subscriptionPaymentModel.ChequeDDTransactionDate,
                                        CreatedBy = CurrentUser.UserId,
                                        CreatedDate = DateTime.Now,
                                        ModifiedBy = CurrentUser.UserId,
                                        ModifiedDate = DateTime.Now,
                                        BankBranch = subscriptionPaymentModel.BankBranch
                                    });
                                }
                            }
                            #endregion

                            #region For Online
                            if (subscriptionPaymentModel.PaymentMode == PaymentMode.Online && clientRegistrationModel.IsOnlineChecked == "true")
                            {

                                if (subscriptionPaymentModel.OnlineAmount != 0 || subscriptionPaymentModel.ChequeDDTransationNo != null
                                    || subscriptionPaymentModel.ChequeDDTransactionDate != null || subscriptionPaymentModel.BankBranch.BranchId != 0)
                                {
                                    clientSubscriptionPaymentDto.Add(new ClientSubscriptionPaymentDetailsDto
                                    {
                                        PaymentMode = PaymentMode.Online,
                                        Amount = subscriptionPaymentModel.OnlineAmount,
                                        ChequeDDTransationNo = subscriptionPaymentModel.ChequeDDTransationNo,
                                        ChequeDDTransactionDate = subscriptionPaymentModel.ChequeDDTransactionDate,
                                        IsRTGS = subscriptionPaymentModel.IsRTGS,
                                        IsNEFT = subscriptionPaymentModel.IsNEFT,
                                        CreatedBy = CurrentUser.UserId,
                                        CreatedDate = DateTime.Now,
                                        ModifiedBy = CurrentUser.UserId,
                                        ModifiedDate = DateTime.Now,
                                        BankBranch = subscriptionPaymentModel.BankBranch
                                    });
                                }

                            }
                            #endregion
                        }
                        NewClientDto.ClientSubscription.ClientSubscriptionPaymentDetails = clientSubscriptionPaymentDto;
                    }
                    #endregion

                    #endregion

                    #region CompanyLogoUploadedImage
                    if (Session["ClientLogoUploadedImageFileName"] != null)
                    {
                        string logoNamewithGuid = Session["ClientLogoUploadedImageFileName"].ToString();
                        NewClientDto.Image = logoNamewithGuid;
                    }
                    #endregion

                    #region Service Request/Response
                    if (model.mode == "edit" && Caid != null)
                    {
                        NewClientDto.CAId = Convert.ToInt32(Caid);
                        NewClientDto = clientService.Update(NewClientDto, CurrentUser.UserName);
                    }
                    else
                    {
                        NewClientDto.CreatedBy = CurrentUser.UserId;
                        NewClientDto.CreatedDate = DateTime.Now;
                        NewClientDto = clientService.Create(NewClientDto, CurrentUser.UserName);
                    }

                    hasWarnings = NewClientDto.Response.HasWarning;
                    if (NewClientDto.Response.HasWarning)
                    {
                        ViewData["Error"] = ClientResources.CLRError;
                        int i = 0;
                        if (saveMode == "Saveandsubmit")
                        {
                            foreach (BusinessWarning buiBusinessWarning in NewClientDto.Response.BusinessWarnings)
                            {
                                System.Resources.ResourceManager resMgr = ErrorAndValidationMessages.ResourceManager;
                                string sErrMgs = resMgr.GetString(buiBusinessWarning.Message);
                                sErrMgs = string.IsNullOrEmpty(sErrMgs) ? buiBusinessWarning.Message : sErrMgs;

                                ModelState.AddModelError("err" + (++i).ToString(), sErrMgs);
                            }
                        }
                        else if (saveMode == "SaveasDraft")
                        {
                            TempData["Success"] = "Client Registration saved with warnings";
                        }
                    }
                    else
                    {
                        if (saveMode == "Saveandsubmit")
                        TempData["Success"] = ClientResources.CLRSuccess;
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            finally
            {
                if (clientService != null && clientService.State == System.ServiceModel.CommunicationState.Opened)
                    clientService.Close();
            }
            modelClientRegistration = clientRegistrationModel;
            return View("CompanyProfile", clientRegistrationModel);
        }
        #endregion

        #region SaveMode
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "SaveasDraft")]
        public ActionResult ClientRegistrationSaveasDraft(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistration(clientRegistrationModel, "SaveasDraft");
            if (isModelStateValid)
            {
                TempData["Success"] = "Client Registration partially saved";
                return RedirectToAction("ClientsIndex");
            }
            modelClientRegistration = GetClientModelFromSession();
            return View("CompanyProfile", modelClientRegistration);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Savecontinue")]
        public ActionResult ClientRegistrationSavecontinue(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistration(clientRegistrationModel, "Saveandcontinue");
            return View("CompanyProfile", modelClientRegistration);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Savesubmit")]
        public ActionResult ClientRegistrationSavesubmit(ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistration(clientRegistrationModel, "Saveandsubmit");
            if (!hasWarnings)
            {
                return RedirectToAction("ClientsIndex");
            }
            modelClientRegistration = GetClientModelFromSession();
            return View("CompanyProfile", modelClientRegistration);
        }
        #endregion

        private void UpdateSessionForCurrentTab(string CurrentTab, ClientRegistrationModel clientRegistrationModel)
        {
            ClientRegistrationModel model = GetClientModelFromSession();
            switch (Convert.ToInt32(CurrentTab))
            {
                case 0:
                    SaveCompanyProfile(clientRegistrationModel);
                    break;
                case 1:
                    SavePrimaryContactDetails(clientRegistrationModel);
                    break;
                case 2:
                    SaveAPMCDetails(clientRegistrationModel);
                    break;
                case 3:
                    SaveBusinessConstitution(clientRegistrationModel);
                    break;
                case 4:
                    SaveSubscriptionDetails(clientRegistrationModel);
                    break;
                case 5:
                    SavePaymentDetails(5, clientRegistrationModel.AdditionalInfoForSubscriptionPayment, clientRegistrationModel.TDSOnSubscriptionPayment);
                    break;
                case 6:
                    SaveAccountmanager(clientRegistrationModel.AccountManagerId);
                    break;
            }
        }

        #region Business Constitution

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "AddClientPartner")]
        public ActionResult AddClientPartner(ClientRegistrationModel clientRegistrationModel)
        {
            string PreviousPage = "CompanyProfile";
            string ActiveTab = "3";
            string IsPartner = string.Empty;
            BusinessConstitutionModel BCModel = new BusinessConstitutionModel();
            if (ComboBoxExtension.GetValue<object>("cmbBusinessContitutions") != null)
            {
                BCModel.BusinessConstitutionId = ComboBoxExtension.GetValue<int>("cmbBusinessContitutions");
                BusinessConstitutionServiceReference.BusinessConstitutionServiceClient BCServiceClient = new BusinessConstitutionServiceClient();
                BusinessConstitutionDto BCDto = BCServiceClient.GetById(BCModel.BusinessConstitutionId);
                if (BCDto.BusinessConstitutionName.Contains("Partner"))
                {
                    IsPartner = "true";
                }
            }
            BCModel.NoOfClientPartners = Convert.ToInt32(Request.Params["businessConstitutionModel.NoOfClientPartners"]);
            //BCModel.NoOfClientPartnersAdded = Convert.ToInt32(Request.Params["businessConstitutionModel.NoOfClientPartnersAdded"]);

            Session["PreviousPage"] = PreviousPage;
            Session["ClientRegistrationActiveTab"] = ActiveTab;
            Session["BusinessConstitution"] = BCModel;

            int ActivePartnerCount = 0;
            if (Session["ClientPartners"] != null)
            {
                ActivePartnerCount = (((List<ClientPartnerDetailsDto>)Session["ClientPartners"])).Where(x => x.IsActive == true).Count();
            }

            if (ActivePartnerCount < BCModel.NoOfClientPartners)
            {
                return RedirectToAction("AddClientPartnerIndex", new { mode = clientRegistrationModel.mode, ispartner = IsPartner });
            }
            else
            {
                TempData["AddClientPartnerError"] = ErrorAndValidationMessages.AddClientPartnerError;
                clientRegistrationModel = SetBusinessConstitution(clientRegistrationModel);
                return View("CompanyProfile", clientRegistrationModel);
            }
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "EditBusinessConstitution")]
        public ActionResult EditClientPartners(ClientRegistrationModel clientRegistrationModel)
        {
            string PreviousPage = "CompanyProfile";
            string ActiveTab = "3";
            string IsPartner = string.Empty;
            BusinessConstitutionModel BCModel = new BusinessConstitutionModel();
            if (ComboBoxExtension.GetValue<object>("cmbBusinessContitutions") != null)
            {
                BCModel.BusinessConstitutionId = ComboBoxExtension.GetValue<int>("cmbBusinessContitutions");
                BusinessConstitutionServiceReference.BusinessConstitutionServiceClient BCServiceClient = new BusinessConstitutionServiceClient();
                BusinessConstitutionDto BCDto = BCServiceClient.GetById(BCModel.BusinessConstitutionId);
                if (BCDto.BusinessConstitutionName.Contains("Partner"))
                {
                    IsPartner = "true";
                }
            }
            BCModel.NoOfClientPartners = Convert.ToInt32(Request.Params["businessConstitutionModel.NoOfClientPartners"]);
            BCModel.NoOfClientPartnersAdded = Convert.ToInt32(Request.Params["businessConstitutionModel.NoOfClientPartnersAdded"]);

            int id = Convert.ToInt32(Request.Params["businessConstitutionModel.PartnerId"]);
            Session["PreviousPage"] = PreviousPage;
            Session["ClientRegistrationActiveTab"] = ActiveTab;
            Session["BusinessConstitution"] = BCModel;

            return RedirectToAction("AddClientPartnerIndex", new { mode = clientRegistrationModel.mode, cpmode = "edit", partnerid = id, ispartner = IsPartner });
        }

        public ClientRegistrationModel SetBusinessConstitution(ClientRegistrationModel model)
        {
            if (Session["BusinessConstitution"] != null)
            {
                model.businessConstitutionModel = (BusinessConstitutionModel)Session["BusinessConstitution"];
                Session.Remove("BusinessConstitution");
            }
            else
            {
                model.businessConstitutionModel.NoOfClientPartners = 1;
                model.businessConstitutionModel.NoOfClientPartnersAdded = 0;
            }
            if (Session["ClientPartners"] != null)
            {
                model.businessConstitutionModel.ClientPartners = ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]);
                model.businessConstitutionModel.NoOfClientPartnersAdded = model.businessConstitutionModel.ClientPartners.Count;
            }
            if (model.businessConstitutionModel.BusinessConstitutionId > 0)
            {
                int id = model.businessConstitutionModel.BusinessConstitutionId;
                model.businessConstitutionModel.SelectedIndex = BusinessConstitutionModel.GetBusinessConstitution().FindIndex(x => x.BusinessConstitutionId == id);
            }
            else
            {
                model.businessConstitutionModel.SelectedIndex = 0;
            }
            return model;
        }

        #endregion

        #region AccountManager
        public JsonResult GetAccountManagerDetails(int AccountManagerId)
        {
            List<string> Result = new List<string>();
            UserServiceReference.UserServiceClient UserClient = null;
            try
            {
                UserClient = new UserServiceReference.UserServiceClient();
                UserDto userDto = UserClient.GetById(AccountManagerId);
                if (userDto != null)
                {
                    Result.Add(userDto.UserId.ToString());
                    Result.Add(userDto.Name);
                    Result.Add(userDto.UserName);
                    Result.Add(userDto.Email);
                    Result.Add(userDto.MobileNo);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (UserClient != null && UserClient.State == System.ServiceModel.CommunicationState.Opened)
                    UserClient.Close();
            }
            return Json(Result);
        }
        #endregion

        #endregion

        #region UploadImage
        public ActionResult CallbacksImageUpload(ClientRegistrationModel model)
        {
            UploadImagePath = Server.MapPath(Url.Content(Constants.IMAGEUPLOADCLIENTLOGO));
            UploadControlExtension.GetUploadedFiles("ClientLogoUpload", UploadControlDemosHelper.ValidationSettings,
                                                    UploadControlDemosHelper.UploadImage);
            Session["ClientLogoUploadedImageFileName"] = UploadedImageFileName;
            return null;
        }

        public ActionResult PCPCallbacksImageUpload(ClientRegistrationModel model)
        {
            UploadImagePath = Server.MapPath(Url.Content(Constants.IMAGEUPLOADPATHPRIMARYCONTACTPERSON));
            UploadControlExtension.GetUploadedFiles("PCPImageUpload", UploadControlDemosHelper.ValidationSettings,
                                                    UploadControlDemosHelper.UploadImage);
            Session["PrimaryContactPersonUploadedImageFileName"] = UploadedImageFileName;
            return null;
        }
        #endregion

        public ActionResult Error()
        {
            return View("ErrorPage");
        }

        public void CheckForValidation(ClientRegistrationModel model)
        {
            if (model.ClientPartners != null && model.ClientPartners.Count > 0)
            {
                if (model.ClientBusinessConstitution != null && model.ClientPartners != null && model.NoOfPartners > 0)
                {
                    if (model.ClientPartners.Count != model.NoOfPartners)
                    {
                        ModelState.AddModelError("errorbc", "Number of Partners added is less than given number of partners.");
                    }
                }
            }
        }

        public void RemoveClientRegistrationSessions()
        {
            Session.Remove("PreviousPage");
            Session.Remove("ClientRegistrationActiveTab");
            Session.Remove("CompanyProfile");
            Session.Remove("BusinessConstitution");
            Session.Remove("ClientPartners");
            Session.Remove("ClientSubscriptionPaymentDetailsModel");
            Session.Remove("ClientLogoUploadedImageFileName");
            Session.Remove("PrimaryContactPersonUploadedImageFileName");
            Session.Remove("AOUploadedImageFileName");
            Session.Remove("AOGuardianCallbacksImageUpload");
        }
    }
}

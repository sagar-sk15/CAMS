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

        string cpmode = string.Empty;
        string partnerid = string.Empty;
        
        //[CamsAuthorize(Roles = Constants.APMC, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult AddClientPartnerIndex()
        {
            ClientPartnersModel CPModel = new ClientPartnersModel();
            if (Request.QueryString["cpmode"] != null)
            {
                cpmode = Request.QueryString["cpmode"].ToString();
            }
            if (Request.QueryString["partnerid"] != null)
            {
                partnerid = Request.QueryString["partnerid"].ToString();
            }
            ClientPartnerDetailsDto clientPartnerDto = new ClientPartnerDetailsDto();
            if (!String.IsNullOrEmpty(cpmode) && !String.IsNullOrEmpty(partnerid))
            {
                #region Set Client Partner
                clientPartnerDto = ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]).Find(x => x.PartnerId == Convert.ToInt32(partnerid));
                CPModel.Title = clientPartnerDto.Title;
                CPModel.PartnerName = clientPartnerDto.PartnerName;
                CPModel.ClientPartnerDesignation = clientPartnerDto.ClientPartnerDesignation;
                CPModel.Gender = clientPartnerDto.Gender;
                CPModel.designationModel[0].SelectedId = clientPartnerDto.ClientPartnerDesignation.DesignationId;
                CPModel.dOBnAgeModellist[0].BindDate = clientPartnerDto.DateOfBirth != null ? Convert.ToDateTime(clientPartnerDto.DateOfBirth) : DateTime.Now;
                CPModel.JoiningDate = clientPartnerDto.JoiningDate != DateTime.MinValue ? Convert.ToDateTime(clientPartnerDto.JoiningDate) : DateTime.Now;
                CPModel.RelievingDate = clientPartnerDto.RelievingDate != DateTime.MinValue && clientPartnerDto.RelievingDate != Helper.SetDefaultDate() ? Convert.ToDateTime(clientPartnerDto.RelievingDate) : Helper.SetDefaultDate();
                CPModel.PAN = clientPartnerDto.PAN;
                CPModel.UID = clientPartnerDto.UID;
                CPModel.IsActive = clientPartnerDto.IsActive;
                CPModel.Image = clientPartnerDto.Image;
                CPModel.ClientPartnerAddress = clientPartnerDto.ClientPartnerAddress;
                CPModel.ClientPartnerContacts = clientPartnerDto.ClientPartnerContacts.ToList();
                CPModel.Email1 = clientPartnerDto.Email1;
                CPModel.Email2 = clientPartnerDto.Email2;

                if (CPModel.ClientPartnerAddress != null)
                {
                    if (CPModel.ClientPartnerAddress.CityVillage != null)
                    {
                        CPModel.ClientPartnerAddress.CityVillage.CityVillageId =
                           CPModel.ClientPartnerAddress.CityVillage.CityVillageId;

                        CPModel.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue = CPModel.ClientPartnerAddress.CityVillage.CityVillageId;
                        CPModel.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue =
                            CPModel.ClientPartnerAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                        CPModel.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue =
                            CPModel.ClientPartnerAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                    }
                }
                #endregion

                #region Set Client Partner Gardian
                if (clientPartnerDto.ClientPartnerGuardian != null)
                {
                    CPModel.ClientPartnerGuardian = clientPartnerDto.ClientPartnerGuardian;
                    CPModel.dOBnAgeModellist[1].BindDate = (CPModel.ClientPartnerGuardian.DateOfBirth != DateTime.MinValue) ? Convert.ToDateTime(CPModel.ClientPartnerGuardian.DateOfBirth) : DateTime.Now;//CPModel.ClientPartnerGuardian.DateOfBirth != Helper.SetDefaultDate() && 

                    if (clientPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts != null)
                    {
                        CPModel.ClientPartnerGuardian.ClientPartnerGuardianContacts = clientPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts.ToList();
                    }

                    if (CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress != null)
                    {
                        if (CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage != null)
                        {
                            CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage.CityVillageId =
                               CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage.CityVillageId;

                            CPModel.StateDistrictPlacesControlNames[1].HiddenFieldForCityVillageValue = CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage.CityVillageId;
                            CPModel.StateDistrictPlacesControlNames[1].HiddenFieldForStateValue =
                                CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                            CPModel.StateDistrictPlacesControlNames[1].HiddenFieldForDistrictValue =
                                CPModel.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                        }
                    }
                }
                #endregion
            }
            return View("ClientPartnersAdd", CPModel);
        }

        //[CamsAuthorize(Roles = Constants.APMC, Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        [HttpPost]
        public ActionResult AddClientPartnerToSession([ModelBinder(typeof(DevExpressEditorsBinder))]ClientPartnersModel CPmodel)
        {
            ViewData["Error"] = null;
            TempData["Success"] = null;
            if (Request.QueryString["cpmode"] != null)
            {
                cpmode = Request.QueryString["cpmode"].ToString();
            }
            if (Request.QueryString["partnerid"] != null)
            {
                partnerid = Request.QueryString["partnerid"].ToString();
            }
            string mode = string.Empty;
            if (Request.QueryString["mode"] != null)
            {
                mode = Request.QueryString["mode"].ToString();
            }
            ClientPartnerDetailsDto NewPartnerDto = new ClientPartnerDetailsDto();
            DesignationServiceReference.DesignationServiceClient DesignationClient = null;
            CityVillageServiceReference.CityVillageServiceClient CityClient = null;

            try
            {
                if (CPmodel.StateDistrictPlacesControlNames != null)
                {
                    for (int i = 0; i < CPmodel.StateDistrictPlacesControlNames.Count; i++)
                    {
                        CPmodel.StateDistrictPlacesControlNames[i].HiddenFieldForCityVillageValue =
                            !String.IsNullOrEmpty(Request.Params[CPmodel.StateDistrictPlacesControlNames[i].PlacesComboName + "_VI"]) ?
                            Convert.ToInt32(Request.Params[CPmodel.StateDistrictPlacesControlNames[i].PlacesComboName + "_VI"]) : 0;
                        CPmodel.StateDistrictPlacesControlNames[i].HiddenFieldForDistrictValue =
                            !String.IsNullOrEmpty(Request.Params[CPmodel.StateDistrictPlacesControlNames[i].DistrictComboName + "_VI"]) ?
                            Convert.ToInt32(Request.Params[CPmodel.StateDistrictPlacesControlNames[i].DistrictComboName + "_VI"]) : 0;
                        CPmodel.StateDistrictPlacesControlNames[i].HiddenFieldForStateValue =
                            !String.IsNullOrEmpty(Request.Params[CPmodel.StateDistrictPlacesControlNames[i].StateComboName + "_VI"]) ?
                            Convert.ToInt32(Request.Params[CPmodel.StateDistrictPlacesControlNames[i].StateComboName + "_VI"]) : 0;
                    }
                }

                if (EditorExtension.GetValue<object>(CPmodel.dOBnAgeModellist[0].txtDOBnAgeName) != null)
                {
                    CPmodel.dOBnAgeModellist[0].BindDate = EditorExtension.GetValue<DateTime>(CPmodel.dOBnAgeModellist[0].txtDOBnAgeName);
                }
                if (ComboBoxExtension.GetValue<object>(CPmodel.designationModel[0].DDLDesignations) != null)
                {
                    CPmodel.designationModel[0].SelectedId = ComboBoxExtension.GetValue<int>(CPmodel.designationModel[0].DDLDesignations);
                }
                if (EditorExtension.GetValue<object>("txtJoiningDate") != null)
                {
                    CPmodel.JoiningDate = EditorExtension.GetValue<DateTime>("txtJoiningDate");
                }
                if (EditorExtension.GetValue<object>("txtRelievingDate") != null)
                {
                    CPmodel.RelievingDate = EditorExtension.GetValue<DateTime>("txtRelievingDate");
                }
                if (EditorExtension.GetValue<object>(CPmodel.dOBnAgeModellist[1].txtDOBnAgeName) != null)
                {
                    CPmodel.dOBnAgeModellist[1].BindDate = EditorExtension.GetValue<DateTime>(CPmodel.dOBnAgeModellist[1].txtDOBnAgeName);
                }

                CheckForAOValidation(CPmodel, mode);

                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];

                if (ModelState.IsValid)
                {
                    #region Client Partner Details

                    NewPartnerDto.PartnerName = CPmodel.PartnerName;
                    NewPartnerDto.Gender = CPmodel.Gender;
                    NewPartnerDto.PAN = CPmodel.PAN;
                    NewPartnerDto.UID = CPmodel.UID;
                    NewPartnerDto.IsActive = CPmodel.IsActive;
                    NewPartnerDto.Email1 = CPmodel.Email1;
                    NewPartnerDto.Email2 = CPmodel.Email2;
                    NewPartnerDto.ModifiedBy = CurrentUser.UserId;
                    NewPartnerDto.ModifiedDate = DateTime.Now;

                    #region Partner Designation
                    DesignationDto designationDto = null;
                    if (CPmodel.designationModel[0].SelectedId > 0)
                    {
                        DesignationClient = new DesignationServiceClient();
                        designationDto = DesignationClient.GetById(CPmodel.designationModel[0].SelectedId);
                    }
                    if (designationDto != null)
                    {
                        NewPartnerDto.ClientPartnerDesignation = designationDto;
                    }
                    #endregion

                    #region Date fields
                    if (CPmodel.dOBnAgeModellist[0].BindDate != DateTime.MinValue)
                    {
                        NewPartnerDto.DateOfBirth = CPmodel.dOBnAgeModellist[0].BindDate;
                    }
                    if (CPmodel.JoiningDate != DateTime.MinValue)
                    {
                        NewPartnerDto.JoiningDate = CPmodel.JoiningDate;
                    }
                    if (CPmodel.RelievingDate != DateTime.MinValue && CPmodel.RelievingDate != Helper.SetDefaultDate())
                    {
                        NewPartnerDto.RelievingDate = CPmodel.RelievingDate;
                    }
                    
                    #endregion

                    #region Partner Address,City/Village
                    int cityVillageID = 0;
                    if (CPmodel.ClientPartnerAddress != null)
                    {
                        NewPartnerDto.ClientPartnerAddress = CPmodel.ClientPartnerAddress;
                        if (CPmodel.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue > 0)
                        {
                            cityVillageID = ComboBoxExtension.GetValue<int>(CPmodel.StateDistrictPlacesControlNames[0].PlacesComboName);
                            CityClient = new CityVillageServiceClient();
                            CityVillageDto cityVillageDto = CityClient.GetById(cityVillageID);
                            if (cityVillageDto != null)
                                NewPartnerDto.ClientPartnerAddress.CityVillage = cityVillageDto;
                            CityClient.Close();
                        }
                    }
                    #endregion

                    #region Partner Contact Details
                    NewPartnerDto.ClientPartnerContacts = CPmodel.ClientPartnerContacts;
                    if (NewPartnerDto.ClientPartnerContacts != null && NewPartnerDto.ClientPartnerContacts.Count == 1)
                    {
                        if (NewPartnerDto.ClientPartnerContacts[0].ContactNo == null)
                        {
                            NewPartnerDto.ClientPartnerContacts.RemoveAt(0);
                        }
                    }
                    #endregion
                    
                    #endregion

                    #region Gardian Details
                    bool isMinor = false;
                    if (CPmodel.dOBnAgeModellist[0].BindDate != DateTime.MinValue)
                    {
                        isMinor = IsMinor(CPmodel.dOBnAgeModellist[0].BindDate);
                    }
                    if (CPmodel.ClientPartnerGuardian != null && isMinor)
                    {
                        NewPartnerDto.ClientPartnerGuardian = CPmodel.ClientPartnerGuardian;

                        if (CPmodel.dOBnAgeModellist[1].BindDate != DateTime.MinValue)
                            NewPartnerDto.ClientPartnerGuardian.DateOfBirth = CPmodel.dOBnAgeModellist[1].BindDate;

                        if (CPmodel.ClientPartnerGuardian.ClientPartnerGuardianAddress != null)
                        {
                            //NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianAddress = CPmodel.ClientPartnerGuardian.ClientPartnerGuardianAddress;
                            if (CPmodel.StateDistrictPlacesControlNames[1].HiddenFieldForStateValue > 0)
                            {
                                cityVillageID = ComboBoxExtension.GetValue<int>(CPmodel.StateDistrictPlacesControlNames[1].PlacesComboName);
                                CityClient = new CityVillageServiceClient();
                                CityVillageDto cityVillageDto = CityClient.GetById(cityVillageID);
                                if (cityVillageDto != null)
                                    NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianAddress.CityVillage = cityVillageDto;
                                CityClient.Close();
                            }
                        }

                        //NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts = CPmodel.ClientPartnerGuardian.ClientPartnerGuardianContacts;
                        if (NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts != null && NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts.Count == 1)
                        {
                            if (NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts[0].ContactNo == null)
                            {
                                NewPartnerDto.ClientPartnerGuardian.ClientPartnerGuardianContacts.RemoveAt(0);
                            }
                        }
                    }
                    #endregion

                    #region Session Part
                    if (Session["AOUploadedImageFileName"] != null)
                    {
                        NewPartnerDto.Image = Session["AOUploadedImageFileName"].ToString();
                    }
                    if (Session["AOGuardianCallbacksImageUpload"] != null)
                    {
                        NewPartnerDto.ClientPartnerGuardian.Image = Session["AOGuardianCallbacksImageUpload"].ToString();
                    }

                    if (Session["ClientPartners"] == null)
                    {
                        Session["ClientPartners"] = new List<ClientPartnerDetailsDto>();
                    }

                    

                    int index = 0;
                    if (!String.IsNullOrEmpty(cpmode) && !String.IsNullOrEmpty(partnerid))
                    {
                        index = ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]).FindIndex(x => x.PartnerId == Convert.ToInt32(partnerid));
                        ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]).RemoveAt(index);
                        ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]).Insert(index, NewPartnerDto);
                    }
                    else
                    {
                        NewPartnerDto.CreatedBy = CurrentUser.UserId;
                        NewPartnerDto.CreatedDate = DateTime.Now;
                        NewPartnerDto.PartnerId = (((List<ClientPartnerDetailsDto>)Session["ClientPartners"]).Count) + 1;
                        ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]).Add(NewPartnerDto);
                    }
                    #endregion
                    return RedirectToAction("ClientRegistrationIndex", "ClientAccount", new { mode = mode });
                }
                else
                {
                    ViewData["Error"] = "error";
                }
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            return View("ClientPartnersAdd", CPmodel);
        }

        public ActionResult AOCallbacksImageUpload(ClientRegistrationModel model)
        {
            UploadImagePath = Server.MapPath(Url.Content(Constants.IMAGEUPLOADPATHCLIENTPARTNERS));
            UploadControlExtension.GetUploadedFiles("AOImageUpload", UploadControlDemosHelper.ValidationSettings,
                                                    UploadControlDemosHelper.UploadImage);
            Session["AOUploadedImageFileName"] = UploadedImageFileName;
            return null;
        }
        public ActionResult AOGuardianCallbacksImageUpload(ClientRegistrationModel model)
        {
            UploadImagePath = Server.MapPath(Url.Content(Constants.IMAGEUPLOADPATHCLIENTPARTNERGUARDIAN));
            UploadControlExtension.GetUploadedFiles("AOGuardianImageUpload", UploadControlDemosHelper.ValidationSettings,
                                                    UploadControlDemosHelper.UploadImage);
            Session["AOGuardianCallbacksImageUpload"] = UploadedImageFileName;
            return null;
        }

        public void CheckForAOValidation(ClientPartnersModel model, string mode)
        {

            #region Client Partner
            if (String.IsNullOrEmpty(model.ClientPartnerAddress.AddressLine1))
            {
                ModelState.AddModelError("erraddr1", ErrorAndValidationMessages.AOReqAddr1);
            }
            if (String.IsNullOrEmpty(model.ClientPartnerAddress.PIN))
            {
                ModelState.AddModelError("errreqpin", ErrorAndValidationMessages.AOReqPIN);
            }
            if (!String.IsNullOrEmpty(model.ClientPartnerAddress.PIN) && !Regex.IsMatch(model.ClientPartnerAddress.PIN, Constants.REGEXPIN))
            {
                ModelState.AddModelError("errregxpin", ErrorAndValidationMessages.AORegExPIN);
            }


            if (model.ClientPartnerContacts != null)
            {
                List<ContactDetailsDto> contactDetailsDto = model.ClientPartnerContacts.Where(x => x.ContactNo == null).ToList();
                if (contactDetailsDto != null)
                {
                    foreach (ContactDetailsDto contact in contactDetailsDto)
                    {
                        model.ClientPartnerContacts.Remove(contact);
                    }
                }
                if (String.IsNullOrEmpty(Helper.GetMobileNoFromContacts(model.ClientPartnerContacts)))
                {
                    ModelState.AddModelError("erraonomob", ErrorAndValidationMessages.AOPIReqMobNo);
                }
                foreach (ContactDetailsDto contact in model.ClientPartnerContacts)
                {
                    if (!String.IsNullOrEmpty(contact.ContactNo) && (!Regex.IsMatch(contact.ContactNo, Constants.REGEXCONTACTNO)))
                    {
                        ModelState.AddModelError(contact.ContactNo, ErrorAndValidationMessages.AOPIRegExContactNo);
                        break;
                    }
                }
            }

            if (EditorExtension.GetValue<object>(model.dOBnAgeModellist[0].txtDOBnAgeName) == null)
            {
                ModelState.AddModelError("errdob", ErrorAndValidationMessages.AOPIReqCity);
            }

            int cityVillageID = 0;
            if (ComboBoxExtension.GetValue<object>(model.StateDistrictPlacesControlNames[0].PlacesComboName) != null)
            {
                cityVillageID = ComboBoxExtension.GetValue<int>(model.StateDistrictPlacesControlNames[0].PlacesComboName);
                if (cityVillageID <= 0)
                {
                    ModelState.AddModelError("erraocity", ErrorAndValidationMessages.AOPIReqCity);
                }
            }
            else
            {
                ModelState.AddModelError("erraocity", ErrorAndValidationMessages.AOPIReqCity);
            }

            int DesignationId = 0;
            if (ComboBoxExtension.GetValue<object>(model.designationModel[0].DDLDesignations) != null)
            {
                DesignationId = ComboBoxExtension.GetValue<int>(model.designationModel[0].DDLDesignations);
                if (DesignationId <= 0)
                {
                    ModelState.AddModelError("erraodesignation", ErrorAndValidationMessages.AOPIReqDesignation);
                }
            }
            else
            {
                ModelState.AddModelError("erraodesignation", ErrorAndValidationMessages.AOPIReqDesignation);
            }


            DateTime dob;
            if (EditorExtension.GetValue<object>(model.dOBnAgeModellist[0].txtDOBnAgeName) != null)
            {
                dob = EditorExtension.GetValue<DateTime>(model.dOBnAgeModellist[0].txtDOBnAgeName);
                if (dob == null)
                {
                    ModelState.AddModelError("errreqdesignation", ErrorAndValidationMessages.AOPIReqExDOB);
                }
                else
                {
                    if (dob.Year < Convert.ToInt32(Constants.MINVALIDYEAR))
                    {
                        ModelState.AddModelError("errregxdesignation", ErrorAndValidationMessages.AOPIRegXExDOB);
                    }

                }
            }
            else
            {
                ModelState.AddModelError("errreqdesignation", ErrorAndValidationMessages.AOPIReqExDOB);
            }

            ClientRegistrationModel CRModel = null;
            int AllowedFarewellYearFrom = 0;
            int AllowedFarewellYearTo = 0;
            DateTime FarewellDate = Convert.ToDateTime(model.RelievingDate);
            if (Session["CompanyProfile"] != null && !String.IsNullOrEmpty(mode) && !String.IsNullOrEmpty(cpmode)
                && FarewellDate != DateTime.MinValue && FarewellDate != Helper.SetDefaultDate())
            {
                CRModel = (ClientRegistrationModel)Session["CompanyProfile"];
                if (CRModel.ClientSubscription.SubscriptionPeriodFromDate != DateTime.MinValue && CRModel.ClientSubscription.SubscriptionPeriodToDate != DateTime.MinValue && CRModel.ClientSubscription.SubscriptionPeriod > 0)
                {
                    int SubscriptionYearFrom = Convert.ToDateTime(CRModel.ClientSubscription.SubscriptionPeriodFromDate).Year;
                    int SubscriptionMonthFrom = Convert.ToDateTime(CRModel.ClientSubscription.SubscriptionPeriodFromDate).Month;
                    int SubscriptionYearTo = Convert.ToDateTime(CRModel.ClientSubscription.SubscriptionPeriodToDate).Year;
                    int SubscriptionMonthTo = Convert.ToDateTime(CRModel.ClientSubscription.SubscriptionPeriodToDate).Month;
                    int CurrentYear = DateTime.Now.Year;
                    int CurrentMonth = DateTime.Now.Month;

                    if (SubscriptionYearFrom > CurrentYear)
                    {
                        AllowedFarewellYearFrom = SubscriptionYearFrom;
                        AllowedFarewellYearTo = SubscriptionYearFrom + 1;
                    }
                    else if ((SubscriptionYearFrom == CurrentYear && SubscriptionYearTo >= CurrentYear) || (SubscriptionYearFrom < CurrentYear && SubscriptionYearTo >= CurrentYear))
                    {
                        if (CurrentMonth >= 1 && CurrentMonth <= 3)
                        {
                            AllowedFarewellYearFrom = CurrentYear - 1;
                            AllowedFarewellYearTo = CurrentYear;
                        }
                        else
                        {
                            AllowedFarewellYearFrom = CurrentYear;
                            AllowedFarewellYearTo = CurrentYear + 1;
                        }

                    }

                    if (!(FarewellDate.Year >= AllowedFarewellYearFrom && FarewellDate.Year <= AllowedFarewellYearTo))
                    {
                        ModelState.AddModelError("errreqdesignation", ErrorAndValidationMessages.AOPIFarewellDateError);
                    }

                }
            }
            #endregion

            #region Client Partner Gardian
            DateTime DOB = DateTime.MinValue;
            bool isMinor = false;
            if (model.dOBnAgeModellist[0].BindDate != DateTime.MinValue)
            {
                isMinor = IsMinor(model.dOBnAgeModellist[0].BindDate);
            }
            if (model.ClientPartnerGuardian != null && isMinor)
            {
                BusinessConstitutionModel BCModel = new BusinessConstitutionModel();
                BusinessConstitutionDto BCDto = null;
                if (Session["BusinessConstitution"] != null)
                {
                    BCModel = (BusinessConstitutionModel)Session["BusinessConstitution"];
                    BusinessConstitutionServiceReference.BusinessConstitutionServiceClient BCClient = new BusinessConstitutionServiceReference.BusinessConstitutionServiceClient();
                    BCDto = BCClient.GetById(BCModel.BusinessConstitutionId);
                }
                List<ClientPartnerDetailsDto> CPDtos = new List<ClientPartnerDetailsDto>();
                if (Session["ClientPartners"] != null)
                {
                    CPDtos = ((List<ClientPartnerDetailsDto>)Session["ClientPartners"]);
                }

                bool IsMinorAllowed = true;
                if (BCDto != null)
                {
                    if (BCDto.BusinessConstitutionName.Contains("Sole"))
                    {
                        ModelState.AddModelError("errgminors", ErrorAndValidationMessages.ErrorMinorSPClientPartner);
                        IsMinorAllowed = false;
                    }
                    else
                    {
                        int TotalMinorAdded = CPDtos.Where(x => x.ClientPartnerGuardian != null).ToList().Count;

                        if ((BCModel.NoOfClientPartners - TotalMinorAdded) <= 2)
                        {
                            ModelState.AddModelError("errgminors", ErrorAndValidationMessages.ErrorMinorClientPartner);
                            IsMinorAllowed = false;
                        }
                    }
                }

                if (IsMinorAllowed)
                {
                    if (String.IsNullOrEmpty(model.ClientPartnerGuardian.GuardianName))
                    {
                        ModelState.AddModelError("errgnamereq", ErrorAndValidationMessages.GardianReqName);
                    }
                    if (!String.IsNullOrEmpty(model.ClientPartnerGuardian.GuardianName) && !Regex.IsMatch(model.ClientPartnerGuardian.GuardianName, Constants.REGXNAME))
                    {
                        ModelState.AddModelError("errregxgnameregx", ErrorAndValidationMessages.GardianReqgExName);
                    }
                    if (String.IsNullOrEmpty(model.ClientPartnerGuardian.ClientPartnerGuardianAddress.AddressLine1))
                    {
                        ModelState.AddModelError("errreqgaddr1", ErrorAndValidationMessages.AOGReqAddr1);
                    }
                    if (String.IsNullOrEmpty(model.ClientPartnerGuardian.PAN))
                    {
                        ModelState.AddModelError("errreqgPAN", ErrorAndValidationMessages.AOGReqPAN);
                    }
                    if (!String.IsNullOrEmpty(model.ClientPartnerGuardian.PAN) && !Regex.IsMatch(model.ClientPartnerGuardian.PAN, Constants.REGEXPAN))
                    {
                        ModelState.AddModelError("errregxgPAN", ErrorAndValidationMessages.AOGRegExPAN);
                    }

                    if (String.IsNullOrEmpty(model.ClientPartnerGuardian.ClientPartnerGuardianAddress.PIN))
                    {
                        ModelState.AddModelError("errreqgpin", ErrorAndValidationMessages.AOGReqPIN);
                    }

                    if (!String.IsNullOrEmpty(model.ClientPartnerGuardian.ClientPartnerGuardianAddress.PIN) && !Regex.IsMatch(model.ClientPartnerGuardian.ClientPartnerGuardianAddress.PIN, Constants.REGEXPIN))
                    {
                        ModelState.AddModelError("errregxgpin", ErrorAndValidationMessages.AOGRegExPIN);
                    }

                    if (String.IsNullOrEmpty(model.ClientPartnerGuardian.Email1))
                    {
                        ModelState.AddModelError("errreqgemail1", ErrorAndValidationMessages.AOGReqEmail1);
                    }

                    if (!String.IsNullOrEmpty(model.ClientPartnerGuardian.Email1) && !Regex.IsMatch(model.ClientPartnerGuardian.Email1, Constants.REGEXEMAIL))
                    {
                        ModelState.AddModelError("errregxgemail1", ErrorAndValidationMessages.AOGRegExEmail1);
                    }

                    if (!String.IsNullOrEmpty(model.ClientPartnerGuardian.Email2) && !Regex.IsMatch(model.ClientPartnerGuardian.Email2, Constants.REGEXEMAIL))
                    {
                        ModelState.AddModelError("errregxgemail2", ErrorAndValidationMessages.AOGRegExEmail2);
                    }

                    //if (!String.IsNullOrEmpty(model.ClientPartnerGuardian.UID) && !Regex.IsMatch(model.ClientPartnerGuardian.UID, Constants.REGEXUID))
                    //{
                    //    ModelState.AddModelError("errregxguid", ErrorAndValidationMessages.AOGRegExUID);
                    //}

                    if (model.ClientPartnerGuardian.ClientPartnerGuardianContacts != null)
                    {
                        List<ContactDetailsDto> contactDetailsDto = model.ClientPartnerGuardian.ClientPartnerGuardianContacts.Where(x => x.ContactNo == null).ToList();
                        if (contactDetailsDto != null)
                        {
                            foreach (ContactDetailsDto contact in contactDetailsDto)
                            {
                                model.ClientPartnerGuardian.ClientPartnerGuardianContacts.Remove(contact);
                            }
                        }
                        if (String.IsNullOrEmpty(Helper.GetMobileNoFromContacts(model.ClientPartnerGuardian.ClientPartnerGuardianContacts)))
                        {
                            ModelState.AddModelError("errreqgmob", ErrorAndValidationMessages.AOGReqMobNo);
                        }
                        foreach (ContactDetailsDto contact in model.ClientPartnerGuardian.ClientPartnerGuardianContacts)
                        {
                            if (!String.IsNullOrEmpty(contact.ContactNo) && (!Regex.IsMatch(contact.ContactNo, Constants.REGEXCONTACTNO)))
                            {
                                ModelState.AddModelError(contact.ContactNo, ErrorAndValidationMessages.AOPIRegExContactNo);
                                break;
                            }
                        }
                    }

                    if (ComboBoxExtension.GetValue<object>(model.StateDistrictPlacesControlNames[1].PlacesComboName) != null)
                    {
                        cityVillageID = ComboBoxExtension.GetValue<int>(model.StateDistrictPlacesControlNames[1].PlacesComboName);
                        if (cityVillageID <= 0)
                        {
                            ModelState.AddModelError("errreqgcity", ErrorAndValidationMessages.AOGPIReqCity);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("errreqgcity", ErrorAndValidationMessages.AOGPIReqCity);
                    }
                }
            }
            #endregion
        }

        private bool IsMinor(DateTime DOB)
        {
            bool flag = false;
            Age age = Helper.CalculateAge(DOB);
            if (age.Years < 18)
            {
                flag = true;
            }
            return flag;
        }
    }
}

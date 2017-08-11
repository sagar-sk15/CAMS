using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Cams.Common;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.ClientServiceReference;
using Cams.Web.MVCRazor.CountryMasterServiceReference;
using Cams.Web.MVCRazor.DesignationServiceReference;
using Cams.Web.MVCRazor.Models.Account;
using Cams.Web.MVCRazor.StatesMasterServiceReference;
using Cams.Web.MVCRazor.UserGroupServiceReference;
using Cams.Web.MVCRazor.UserServiceReference;
using Cams.Common.Message;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.Mvc;
using System.Threading;
using Cams.Web.MVCRazor.RelationShipServiceReference;
using Cams.Web.MVCRazor.Helpers;
using Cams.Web.MVCRazor.Models.Shared;
using System.Text.RegularExpressions;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {        
        public static string CheckMode = "none";

        [CamsAuthorize(Roles= Constants.MANAGEACKUSERS +","+ Constants.MANAGECLIENTUSERS,
            Permissions=CamsAuthorizeAttribute.RolePermission.Add)]
        public ActionResult UserRegistrationIndex()
        {
            UserRegistrationModel model = new UserRegistrationModel();
            try
            {
                UserDto currentuser = (UserDto)Session[Constants.SKCURRENTUSER];
                ViewData["AgeinYearsMonths"] = "";
                ViewData["Years"] = "0";
                ViewData["Months"] = "0";
                model.DOB = DateTime.Now;
                ViewData["DesignationList"] = GetUserDesignationList();
                ViewData["SelectedDesignationId"] = 0;

                model.UserGroupList.Insert(0, new UserGroupDto
                                                  {
                                                      UserGroupId = 0,
                                                      UserGroupName = "[Select All]"
                                                  });
                ViewData["ModelState"] = model;
                string usertype = string.Empty;
                if (Request.QueryString["usertype"] != null)
                {
                    usertype = Request.QueryString["usertype"];

                    //model.DateOfBirthModel = 
                    //    (!String.IsNullOrEmpty(usertype) && usertype == "AckUser") ?
                    //    SetDOBControl(-18, model.DateOfBirthModel) :
                    //    SetDOBControl(-15, model.DateOfBirthModel);
                }

                if (Request.QueryString["CAId"] != null && Request.Params["CAId"] != null)
                {
                    //model.UserOfClient.CAId = Convert.ToInt32(Request.QueryString["CAId"]);
                    model.UserOfClient = GetClientById();
                    model.CAId = model.UserOfClient.CAId;
                }
                else if (Helper.IsCAIdNotNull(currentuser))
                {
                    model.UserOfClient.CAId = Convert.ToInt32(Helper.GetCAIdOfUser(currentuser));
                    model.CAId = model.UserOfClient.CAId;
                }
                //if (model.UserOfClient.CAId > 0)
                //{
                //    model.DateOfBirthModel = SetDOBControl(-15, model.DateOfBirthModel);                
                //}

                model.UserGroupList = GetUserGroupList(model.UserOfClient.CAId);
                model.ECRelationshipWithUser = GetRelationShips();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
            return View("UserRegistration", model);
        }

        [CamsAuthorize(Roles = Constants.MANAGEACKUSERS + "," + Constants.MANAGECLIENTUSERS,
            Permissions = CamsAuthorizeAttribute.RolePermission.Add)]
        [HttpPost]
        public ActionResult UserRegistration(UserRegistrationModel model)
        {
            UserServiceClient client = null;
            string userType = string.Empty;
            if (Request.QueryString["usertype"] != null)
            {
                userType = Request.QueryString["usertype"];
            }
            try
            {
                ViewData["Error"] = null;
                TempData["Success"] = null;
                model.mode = CheckMode;
                foreach (StateDistrictCityControlNamesModel controlName in model.StateDistrictPlacesControlNames)
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
                if (EditorExtension.GetValue<object>("txtDateofBirth") != null)
                {
                    model.DOB= EditorExtension.GetValue<DateTime>("txtDateofBirth");
                }
                if (ComboBoxExtension.GetValue<object>("ddlECDesignation") != null)
                {
                    model.UserDesignation = new DesignationDto { DesignationId = ComboBoxExtension.GetValue<int>("ddlECDesignation") };
                }
                model.SelectedUserGroupList = !String.IsNullOrEmpty(Request.Params["SelectedUserGroupList"]) ?
                    Request.Params["SelectedUserGroupList"] : "";

                CheckForURValidation(model);

                client = new UserServiceClient();
                UserDto CurrentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                UserDto NewUser = new UserDto();

                if (ModelState.IsValid)
                {
                    if (CheckMode == "Edit")
                    {
                        NewUser = client.GetById(model.UserId);
                    }
                    else
                    {
                        model.GeneratedPassword = Helper.Encode("password"); //Helper.Encode(Helper.GeneratePassword());
                        NewUser.Password = model.GeneratedPassword;
                    }
                    #region Registration

                    

                    if (model.UserOfClient.CAId != 0)
                    {
                        NewUser.UserOfClient = new ClientDto
                        {
                            CAId = model.UserOfClient.CAId
                        };
                    }
                    if (model.CAId != null && model.CAId > 0)
                    {
                        if (NewUser.UserOfClient == null)
                        {
                            NewUser.UserOfClient = new ClientDto();
                        }
                        NewUser.UserOfClient.CAId = Convert.ToInt32(model.CAId);
                    }
                    NewUser.CAId = model.CAId;
                    NewUser.UserName = model.UserName;
                    
                    NewUser.Title = model.Title;
                    NewUser.Name = ConvertToCamelCase(model.Name);
                    NewUser.DateOfBirth = model.DateOfBirth;
                    NewUser.Email = model.Email;
                    NewUser.CountryCode = model.CountryCode;
                    NewUser.MobileNo = model.MobileNo;
                    NewUser.IsActive = model.IsActive;
                    NewUser.AllowDelete = true;
                    NewUser.AllowEdit = true;
                    NewUser.MothersMaidenName = model.MothersMaidenName;
                    //NewUser.CreatedBy = CurrentUser.UserId;
                    //NewUser.ModifiedBy = CurrentUser.UserId;
                    #endregion

                    #region UserGroupList
                    string sUGList = Request.Params["SelectedUserGroupList"];

                    if (!String.IsNullOrEmpty(sUGList))
                    {
                        UserGroupDto SelectedUG;
                        string[] UGList = sUGList.Split(';');
                        NewUser.UserWithUserGroups = new List<UserGroupDto>();

                        foreach (string sUserGroupId in UGList)
                        {
                            int ugId = Convert.ToInt32(sUserGroupId);
                            if (ugId != 0)
                            {
                                SelectedUG = new UserGroupDto
                                {
                                    UserGroupId = ugId
                                };
                                NewUser.UserWithUserGroups.Add(SelectedUG);
                            }
                        }
                    }
                    #endregion

                    #region UserDesignation
                    if (!Helper.IsCAIdNotNull(NewUser))
                    {
                        NewUser.UserDesignation = new DesignationDto
                                                        {
                                                            DesignationId = model.UserDesignation.DesignationId
                                                        };

                    }
                    else
                        NewUser.UserDesignation = null;
                    #endregion

                    #region DOB
                    if (EditorExtension.GetValue<object>("txtDateofBirth") != null)
                    {
                        NewUser.DateOfBirth = EditorExtension.GetValue<DateTime>("txtDateofBirth");
                    }
                    #endregion

                    #region UploadedImage
                    if (Session["UploadedImageFileName"] != null)
                    {
                        string imageNamewithGuid = Session["UploadedImageFileName"].ToString();
                        NewUser.Image = imageNamewithGuid;
                    }
                    #endregion

                    #region UserProfile and Emergency Contact
                    if (model.UserProfile != null)
                    {
                        #region UserProfile
                        NewUser.UserProfile = model.UserProfile;
                        //NewUser.UserProfile.ModifiedBy = CurrentUser.UserId;
                        if (CheckMode == "Edit")
                        {
                            NewUser.UserProfile.UserProfileId = model.UserProfile.UserProfileId;
                        }
                        if (model.UserProfile.ContactNos != null)
                        {
                            List<ContactDetailsDto> contactDetailsDto = model.UserProfile.ContactNos.Where(x => x.ContactNo == null).ToList();
                            if (contactDetailsDto != null)
                            {
                                foreach (ContactDetailsDto contact in contactDetailsDto)
                                {
                                    model.UserProfile.ContactNos.Remove(contact);
                                }
                            }
                        }
                        
                        if (NewUser.UserProfile.ContactNos != null && NewUser.UserProfile.ContactNos.Count == 1)
                        {
                            if (NewUser.UserProfile.ContactNos[0].ContactNo == null)
                            {
                                NewUser.UserProfile.ContactNos.RemoveAt(0);
                            }
                        }
                        int cityVillageID = 0;

                        if (model.UserProfile.UserAddress != null)
                        {
                            NewUser.UserProfile.UserAddress = model.UserProfile.UserAddress;
                            if (ComboBoxExtension.GetValue<object>("cmbCityVillage") != null)
                            {
                                cityVillageID = ComboBoxExtension.GetValue<int>("cmbCityVillage");
                                if (cityVillageID > 0)
                                {
                                    NewUser.UserProfile.UserAddress.CityVillage = new CityVillageDto
                                    {
                                        CityVillageId = cityVillageID,
                                    };
                                }
                                else
                                {
                                    NewUser.UserProfile.UserAddress.CityVillage = null;
                                }
                            }
                            if (CheckMode == "Edit" && model.UserProfile.UserAddress.CityVillage != null)
                            {
                                NewUser.UserProfile.UserAddress.CityVillage.CityVillageId =
                                    model.UserProfile.UserAddress.CityVillage.CityVillageId;
                            }
                        }
                        #endregion

                        #region UserEmergencyContactPerson

                        if (!Helper.IsCAIdNotNull(NewUser) && model.UserProfile.UserEmergencyContactPerson != null)
                    {
                        NewUser.UserProfile.UserEmergencyContactPerson = model.UserProfile.UserEmergencyContactPerson;
                        if (CheckMode == "Edit")
                        {
                            NewUser.UserProfile.UserEmergencyContactPerson.UserEmergencyContactPersonId =
                                model.UserProfile.UserEmergencyContactPerson.UserEmergencyContactPersonId;
                        }

                        if (model.UserProfile.UserEmergencyContactPerson.Contacts != null)
                        {
                            List<ContactDetailsDto> contactDetailsDto = model.UserProfile.UserEmergencyContactPerson.Contacts.Where(x => x.ContactNo == null).ToList();
                            if (contactDetailsDto != null)
                            {
                                foreach (ContactDetailsDto contact in contactDetailsDto)
                                {
                                    model.UserProfile.UserEmergencyContactPerson.Contacts.Remove(contact);
                                }
                            }
                        }

                        if (NewUser.UserProfile.UserEmergencyContactPerson.Contacts != null && NewUser.UserProfile.UserEmergencyContactPerson.Contacts.Count == 1)
                        {
                            if (string.IsNullOrEmpty(NewUser.UserProfile.UserEmergencyContactPerson.Contacts[0].ContactNo))
                            {
                                NewUser.UserProfile.UserEmergencyContactPerson.Contacts.RemoveAt(0);
                            }
                        }
                        if (model.UserProfile.UserEmergencyContactPerson.ContactPersonAddress != null)
                        {
                            NewUser.UserProfile.UserEmergencyContactPerson.ContactPersonAddress = model.UserProfile.UserEmergencyContactPerson.ContactPersonAddress;
                            if (ComboBoxExtension.GetValue<object>("ECcmbCityVillage") != null)
                            {
                                cityVillageID = ComboBoxExtension.GetValue<int>("ECcmbCityVillage");

                                if (cityVillageID > 0)
                                {
                                    NewUser.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage = new CityVillageDto
                                    {
                                        CityVillageId = cityVillageID,
                                    };
                                }
                                else
                                {
                                    NewUser.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage = null;
                                }
                            }
                            if (CheckMode == "Edit" && model.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage != null)
                            {
                                NewUser.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.CityVillageId =
                                    model.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.CityVillageId;
                            }
                        }

                        if (model.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser != null)
                        {
                            RelationShipServiceReference.IRelationShipService relationShipClient = new RelationShipServiceClient();
                            NewUser.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser = relationShipClient.GetById(model.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser.RelationshipId);
                        }

                        if (string.IsNullOrEmpty(NewUser.UserProfile.UserEmergencyContactPerson.Name))
                        {
                            NewUser.UserProfile.UserEmergencyContactPerson = null;
                        }
                        //if (NewUser.UserProfile.UserEmergencyContactPerson != null)
                        //{
                        //    NewUser.UserProfile.UserEmergencyContactPerson.ModifiedBy = CurrentUser.UserId;
                        //}
                    }
                    else
                        NewUser.UserProfile.UserEmergencyContactPerson = null;
                    #endregion
                    }
                    #endregion
                    
                    #region Service Request/Response

                    NewUser.ViewOfUserUserGroupRolePermissions = null;
                    NewUser.LastActivityDate = DateTime.Now;
                    Session["UploadedImageFileName"] = null;
                    if (CheckMode == "Edit")
                    {
                        if (NewUser.UserProfile != null)
                            NewUser.UserProfile.ModifiedBy = CurrentUser.UserId;
                        if (NewUser.UserProfile.UserAddress != null)
                            NewUser.UserProfile.UserAddress.ModifiedBy = CurrentUser.UserId;
                        if (NewUser.UserProfile.UserEmergencyContactPerson != null)
                            NewUser.UserProfile.UserEmergencyContactPerson.ModifiedBy = CurrentUser.UserId;

                        NewUser.ModifiedBy = CurrentUser.UserId;

                        NewUser = client.Update(NewUser, CurrentUser.UserName);
                    }
                    else
                    {
                        if (NewUser.UserProfile != null)
                        {
                            NewUser.UserProfile.ModifiedBy = CurrentUser.UserId;
                            NewUser.UserProfile.ModifiedBy = CurrentUser.UserId;
                        }
                        if (NewUser.UserProfile.UserAddress != null)
                        {
                            NewUser.UserProfile.UserAddress.ModifiedBy = CurrentUser.UserId;
                            NewUser.UserProfile.UserAddress.ModifiedBy = CurrentUser.UserId;
                        }
                        if (NewUser.UserProfile.UserEmergencyContactPerson != null)
                        {
                            NewUser.UserProfile.UserEmergencyContactPerson.ModifiedBy = CurrentUser.UserId;
                            NewUser.UserProfile.UserEmergencyContactPerson.ModifiedBy = CurrentUser.UserId;
                        }

                        NewUser.CreatedBy = CurrentUser.UserId;
                        NewUser.ModifiedBy = CurrentUser.UserId;
                        NewUser = client.Create(NewUser, CurrentUser.UserName);
                    }

                    if (NewUser.Response.HasWarning)
                    {
                        ViewData["Error"] = ErrorAndValidationMessages.URRegistrationFailed;
                        int i = 0;
                        foreach (BusinessWarning bw in NewUser.Response.BusinessWarnings)
                        {
                            if (bw.Message == "InValidUserAge")
                            {
                                if (Helper.IsCAIdNotNull(NewUser))
                                {
                                    ModelState.AddModelError("err" + (++i).ToString(), String.Format(ClientResources.InValidUserAge, Constants.CAUSERAGELIMIT));
                                }
                                else
                                {
                                    ModelState.AddModelError("err" + (++i).ToString(), String.Format(ClientResources.InValidUserAge, Constants.ACKUSERAGELIMIT));
                                }
                            }
                            else
                                ModelState.AddModelError("err" + (++i).ToString(), bw.Message);
                        }

                    }
                    else
                    {
                        if (CheckMode == "Edit")
                        {
                            TempData["UserRegisteredSuccessfully"] = "User updated successfully";
                        }
                        else
                        {
                            TempData["UserRegisteredSuccessfully"] = ErrorAndValidationMessages.URRegistrationSuccessful;
                        }
                        if (model.CAId == null || model.CAId==0)
                        {
                            return RedirectToAction("UsersIndex", "Account", new { usertype = userType });
                        }
                        else
                            return RedirectToAction("UsersIndex", "Account", new { usertype = userType, CAId = model.CAId });
                    }
                    #endregion
                }
                else
                {
                    ViewData["Error"] = ErrorAndValidationMessages.URRegistrationFailed;
                }
                if (!Helper.IsCAIdNotNull(NewUser))
                {
                    ViewData["DesignationList"] = GetUserDesignationList();
                    ViewData["SelectedDesignationId"] = model.UserDesignation.DesignationId;
                    //ViewData["SelectedDesignationId"] = 
                    //    (NewUser.UserDesignation != null) ?
                    //    (NewUser.UserDesignation.DesignationId > 0) ? 
                    //    NewUser.UserDesignation.DesignationId : 0 : 0;
                }
                model.ECRelationshipWithUser = GetRelationShips();
                Nullable<int> caID = null;
                if (!string.IsNullOrEmpty(Request.Params["CAId"]))
                    caID = Convert.ToInt32(Request.Params["CAId"]);
                model.UserOfClient = GetClientById();
                model.CAId = caID;
                model.UserGroupList = GetUserGroupList(caID);
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
            if (model.mode == "Edit")
            {
                if (Session["UploadedImageFileName"] != null)
                {
                    model.Image = Session["UploadedImageFileName"].ToString();
                }
            }

            return View("UserRegistration", model);
        }

        public ActionResult GetUpdatedDesignations()
        {
            string AddedDesignationName = Request.Params["AddedDesignation"];
            List<DesignationDto> Designations = GetUserDesignationList();
            ViewData["DesignationList"] = Designations;
            ViewData["SelectedDesignationId"] = Designations.Count > 0 ? Designations.Find(x => x.DesignationName == AddedDesignationName).DesignationId : 0;
            return PartialView("CallBackPanelUserDesignationList");
        }

        public JsonResult CheckUsername(UserRegistrationModel model)
        {
            UserServiceClient client = new UserServiceClient();
            object result = null;
            TempData["SuggUsername"] = null;
            List<string> AvailableUsernames = new List<string>() { };

            if (client.GetByUserName(model.UserName) == null)
                result = true;
            else
            {
                TempData["SuggUsername"] = "something";
                AvailableUsernames =
                    client.GetAvailableUsernameList(
                        ViewData["FullName"] != null ? ViewData["FullName"].ToString() : string.Empty, model.UserName).
                        ToList();
                result = ErrorAndValidationMessages.URUserAlreadyExist;
            }
            client.Close();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string ConvertToCamelCase(string strname)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            string result = textInfo.ToTitleCase(strname);

            return result.Trim();
        }

        public ActionResult GetURAgeInYearsAndMonths()
        {
            string result = null;
            string sDate = Request.Params["newDate"];
            DateTime birthDate = new DateTime();
            
            if (!String.IsNullOrEmpty(sDate))
            {
                string[] sDOB = sDate.Split('-');
                birthDate = new DateTime(Convert.ToInt32(sDOB[2]), Convert.ToInt32(sDOB[1]), Convert.ToInt32(sDOB[0]));
            }

            Age age = Helper.CalculateAge(birthDate);
            result = string.Format(ClientResources.URAgeInYearsMonths, age.Years, age.Months);
            ViewData["AgeinYearsMonths"] = result;
            return PartialView("CBPForDOBAndAge", birthDate);
        }

        private IList<RelationshipDto> GetRelationShips()
        {
            IList<RelationshipDto> relationShipDtoList = new List<RelationshipDto>();
            RelationShipServiceClient client = new RelationShipServiceClient();
            relationShipDtoList = client.FindAll().Entities;
            client.Close();
            return relationShipDtoList;
        }

        private Common.Dto.ClientRegistration.ClientDto GetClientById()
        {
            ClientDto clientDto = null;
            Nullable<int> caId = null;
            if (!String.IsNullOrEmpty(Request.QueryString["CAId"]))
                caId = Convert.ToInt32(Request.QueryString["CAId"]);
            if (!String.IsNullOrEmpty(Request.Params["CAId"]))
                caId = Convert.ToInt32(Request.Params["CAId"]);

            if (caId != null)
            {
                ClientServiceClient clientService = new ClientServiceClient();
                clientDto = clientService.GetById(Convert.ToInt32(caId));
                clientService.Close();
            }

            return clientDto;
        }

        public void CheckForURValidation(UserRegistrationModel model)
        {
            string userType = string.Empty;
            if (Request.QueryString["usertype"] != null)
            {
                userType = Request.QueryString["usertype"];
            }

            if (!String.IsNullOrEmpty(model.UserProfile.PAN) && model.UserProfile.PAN.Length < 10)
            {
                ModelState.AddModelError("errpan", ErrorAndValidationMessages.URRegExPAN);
            }
            if (!String.IsNullOrEmpty(model.UserProfile.UID) && !Regex.IsMatch(model.UserProfile.UID, Constants.REGEXUID))
            {
                ModelState.AddModelError("erruid", ErrorAndValidationMessages.URRegExUID);
            }
            
            if (!String.IsNullOrEmpty(model.UserProfile.UserAddress.PIN) && !Regex.IsMatch(model.UserProfile.UserAddress.PIN, Constants.REGEXPIN))
            {
                ModelState.AddModelError("errpin", ErrorAndValidationMessages.URRegExPIN);
            }
            if (!String.IsNullOrEmpty(model.UserProfile.Email1) && !Regex.IsMatch(model.UserProfile.Email1, Constants.REGEXEMAIL))
            {
                ModelState.AddModelError("erremail1", ErrorAndValidationMessages.URPIRegExEmail1);
            }
            if (!String.IsNullOrEmpty(model.UserProfile.Email2) && (!Regex.IsMatch(model.UserProfile.Email2, Constants.REGEXEMAIL)))
            {
                ModelState.AddModelError("erremail2", ErrorAndValidationMessages.URPIRegExEmail2);
            }

            if (model.UserProfile != null)
            {
                if (model.UserProfile.ContactNos != null)
                {
                    List<ContactDetailsDto> contactDetailsDto = model.UserProfile.ContactNos.Where(x => x.ContactNo == null).ToList();
                    if (contactDetailsDto != null)
                    {
                        foreach (ContactDetailsDto contact in contactDetailsDto)
                        {
                            model.UserProfile.ContactNos.Remove(contact);
                        }
                    }
                    foreach (ContactDetailsDto contact in model.UserProfile.ContactNos)
                    {
                        if (!String.IsNullOrEmpty(contact.ContactNo) && (!Regex.IsMatch(contact.ContactNo, Constants.REGEXCONTACTNO)))
                        {
                            ModelState.AddModelError(contact.ContactNo, ErrorAndValidationMessages.URPIRegExContactNo);
                            break;
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(model.SelectedUserGroupList))
            {
                ModelState.AddModelError("errorusergroup", ErrorAndValidationMessages.URReqUserGroup);
            }
            if (!Helper.IsCAIdNotNull(model))
            {
                if (model.UserDesignation.DesignationId <= 0)
                {
                    ModelState.AddModelError("errordesignation", ErrorAndValidationMessages.URReqDesignation);
                }
            }
        }

        //public DOBModel SetDOBControl(int years, DOBModel model)
        //{
        //    model.BindDate = DateTime.Now.AddYears(years);
        //    model.MaxDate = DateTime.Now.AddYears(years);
        //    return model;
        //}

        #region UploadImage
        public ActionResult CallbacksImageUpload(UserRegistrationModel model)
        {
            UploadImagePath = Server.MapPath(Url.Content(Constants.IMAGEUPLOADPATH));
            UploadControlExtension.GetUploadedFiles("ImageUpload", UploadControlDemosHelper.ValidationSettings,
                                                    UploadControlDemosHelper.UploadImage);
            Session["UploadedImageFileName"] = UploadedImageFileName;
            return View("UserRegistration", Session["UploadedImageFileName"]);
        }

        //public class UploadControlDemosHelper
        //{
        //    public static readonly ValidationSettings
        //        ValidationSettings = new ValidationSettings
        //                            {
        //                                AllowedFileExtensions =
        //                                    new string[]
        //                                        {
        //                                            ".jpg", ".jpeg", ".jpe",
        //                                            ".gif", ".png"
        //                                        },
        //                                MaxFileSize = 20971520
        //                            };


        //    public static void UploadImage(object sender, FileUploadCompleteEventArgs e)
        //    {
        //        if (e.UploadedFile.IsValid)
        //        {
        //            string fileName = e.UploadedFile.FileName;
        //            if (fileName.Contains('_'))
        //            {
        //                fileName = fileName.Replace('_', '-');
        //            }
        //            string imageNameWithGuid = (Guid.NewGuid()).ToString() + "_" + fileName;
        //            string resultFilePath = UploadImagePath + imageNameWithGuid;
        //            using (Image original = Image.FromStream(e.UploadedFile.FileContent))
        //            using (Image thumbnail = PhotoUtils.Inscribe(original, 100))
        //            {
        //                PhotoUtils.SaveToJpeg(thumbnail, resultFilePath);
        //            }
        //            IUrlResolutionService urlResolver = sender as IUrlResolutionService;
        //            if (urlResolver != null)
        //                // e.CallbackData = e.UploadedFile.FileName;
        //                e.CallbackData = imageNameWithGuid;

        //            UploadedImageFileName = imageNameWithGuid;
        //        }
        //    }


        //    public static class PhotoUtils
        //    {
        //        public static Image Inscribe(Image image, int size)
        //        {
        //            return Inscribe(image, size, size);
        //        }

        //        public static Image Inscribe(Image image, int width, int height)
        //        {
        //            Bitmap result = new Bitmap(width, height);
        //            using (Graphics graphics = Graphics.FromImage(result))
        //            {
        //                double factor = 1.0 * width / image.Width;
        //                if (image.Height * factor < height)
        //                    factor = 1.0 * height / image.Height;
        //                Size size = new Size((int)(width / factor), (int)(height / factor));
        //                Point sourceLocation = new Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2);

        //                SmoothGraphics(graphics);
        //                graphics.DrawImage(image, new Rectangle(0, 0, width, height),
        //                                   new Rectangle(sourceLocation, size), GraphicsUnit.Pixel);
        //            }
        //            return result;
        //        }

        //        private static void SmoothGraphics(Graphics g)
        //        {
        //            g.SmoothingMode = SmoothingMode.AntiAlias;
        //            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        //        }

        //        public static void SaveToJpeg(Image image, string filePath)
        //        {
        //            MemoryStream memoryStream = new MemoryStream();
        //            FileStream fileStream = null;
        //            try
        //            {
        //                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
        //                image.Save(memoryStream, ImageFormat.Jpeg);
        //                byte[] bytes = memoryStream.ToArray();
        //                fileStream.Write(bytes, 0, bytes.Length);

        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //            finally
        //            {
        //                memoryStream.Close();
        //                if (fileStream != null)
        //                    fileStream.Close();
        //            }
        //        }

        //    }
        //}
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.Models.Account;
using Cams.Web.MVCRazor.UserServiceReference;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERS + "," + Constants.MANAGECLIENTUSERS
            , Permissions = CamsAuthorizeAttribute.RolePermission.Update)] 
        [HttpGet]
        public ActionResult EditRegisteredUser(string userName, string mode)
        {
            UserServiceClient client = null;
            UserDto userDto = null;
            UserRegistrationModel userRegistrationModel = new UserRegistrationModel();
            userRegistrationModel.mode = mode;//To render controls in edit mode 
            string userType = string.Empty;
            if (Request.QueryString["usertype"] != null)
            {
                userType = Request.QueryString["usertype"];
            }
            try
            {
                UserDto currentUser = (UserDto)Session[Constants.SKCURRENTUSER];
                if (!string.IsNullOrEmpty(userName))
                {
                    client = new UserServiceClient();
                    userDto = client.GetByUserName(userName);
                    if (userDto != null && userDto.AllowEdit)
                    {
                        CheckMode = mode;//Edit Mode
                        userRegistrationModel.UserId = userDto.UserId;
                        userRegistrationModel.UserName = userDto.UserName;

                        if(userDto.UserWithUserGroups != null)
                        userRegistrationModel.UserGroupList = userDto.UserWithUserGroups.ToList();

                        userRegistrationModel.DOB = userDto.DateOfBirth;
                        userRegistrationModel.Name = userDto.Name;
                        userRegistrationModel.IsActive = userDto.IsActive;
                        userRegistrationModel.MothersMaidenName = userDto.MothersMaidenName;
                        userRegistrationModel.ModifiedBy = currentUser.UserId;
                        userRegistrationModel.ModifiedDate = DateTime.Now;
                        if (userDto.Image != null)
                        {
                            userRegistrationModel.Image = userDto.Image;
                            Session["UploadedImageFileName"] = userDto.Image;
                        }
                        userRegistrationModel.Email = userDto.Email;
                        userRegistrationModel.MobileNo = userDto.MobileNo;
                        userRegistrationModel.Title = userDto.Title;
                        if (userDto.UserDesignation != null)
                        {
                            userRegistrationModel.UserDesignation = userDto.UserDesignation;
                            userRegistrationModel.SelectedDesignation = userDto.UserDesignation.DesignationName;
                            userRegistrationModel.UserDesignation.DesignationId = userDto.UserDesignation.DesignationId;
                        }
                        if (userDto.UserProfile != null)
                        {
                            userRegistrationModel.UserProfile = userDto.UserProfile;
                            userRegistrationModel.UserProfile.UserProfileId = userDto.UserProfile.UserProfileId;
                            if (userDto.UserProfile.UserAddress != null)
                            {
                                if (userDto.UserProfile.UserAddress.CityVillage != null)
                                {
                                    userRegistrationModel.UserProfile.UserAddress.CityVillage.CityVillageId =
                                       userDto.UserProfile.UserAddress.CityVillage.CityVillageId;

                                    userRegistrationModel.StateDistrictPlacesControlNames[0].HiddenFieldForCityVillageValue = userDto.UserProfile.UserAddress.CityVillage.CityVillageId;
                                    userRegistrationModel.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue =
                                        userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                                    userRegistrationModel.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue =
                                        userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                                }
                            }
                            if (userDto.UserProfile.UserEmergencyContactPerson != null)
                            {
                                userRegistrationModel.UserProfile.UserEmergencyContactPerson = userDto.UserProfile.UserEmergencyContactPerson;
                                userRegistrationModel.UserProfile.UserEmergencyContactPerson.UserEmergencyContactPersonId = userDto.UserProfile.UserEmergencyContactPerson.UserEmergencyContactPersonId;
                                if (userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress != null)
                                {
                                    if (userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage != null)
                                    {
                                        userRegistrationModel.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.
                                            CityVillage.CityVillageId =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.
                                                CityVillageId;
                                        userRegistrationModel.StateDistrictPlacesControlNames[1].HiddenFieldForCityVillageValue =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.CityVillageId;
                                        userRegistrationModel.StateDistrictPlacesControlNames[1].HiddenFieldForStateValue =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                                        userRegistrationModel.StateDistrictPlacesControlNames[1].HiddenFieldForDistrictValue =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                                    }
                                }
                                if (userDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser != null)
                                {
                                    userRegistrationModel.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser.RelationshipId = userDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser.RelationshipId;
                                }
                            }
                        }
                        ViewData["DesignationList"] = GetUserDesignationList();
                        userRegistrationModel.ECRelationshipWithUser = GetRelationShips();
                        if ((Request.QueryString["CAId"] != null) || (Request.Params["CAId"] != null))
                        {
                            userRegistrationModel.UserOfClient = GetClientById();
                        }
                        else
                        {
                            userRegistrationModel.CAId = userDto.CAId;
                            userRegistrationModel.UserOfClient.CAId = Convert.ToInt32(Helper.GetCAIdOfUser(userDto));
                        }
                        userRegistrationModel.UserGroupList = GetUserGroupList(Helper.GetCAIdOfUser(userDto));
                        //userRegistrationModel.DateOfBirthModel =
                        //    (userType != "AckUser") ?
                        //    SetDOBControl(-18, userRegistrationModel.DateOfBirthModel) :
                        //    SetDOBControl(-15, userRegistrationModel.DateOfBirthModel);
                        
                        

                        foreach (UserGroupDto ug in userDto.UserWithUserGroups)
                        {
                            userRegistrationModel.SelectedUserGroupList = userRegistrationModel.SelectedUserGroupList + ug.UserGroupId + ";";
                        }
                        if (userRegistrationModel.SelectedUserGroupList != null)
                        {
                            userRegistrationModel.SelectedUserGroupList =
                                userRegistrationModel.SelectedUserGroupList.TrimEnd(';');
                        }

                    }
                }
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
            return View("UserRegistration", userRegistrationModel);
        }
    }
}

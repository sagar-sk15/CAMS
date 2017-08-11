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
            , Permissions = CamsAuthorizeAttribute.RolePermission.View)] 
        [HttpGet]
        public ActionResult UserRegistrationView(string userName, string mode)  
        {
            UserServiceClient client = null;
            UserDto userDto = null;
            UserRegistrationModel userRegistrationModel = new UserRegistrationModel();
            userRegistrationModel.mode = mode;//To render controls in view mode 
            try
            {
                UserDto currentUser = (UserDto) Session[Constants.SKCURRENTUSER];
                if (userName != null)
                {
                    client = new UserServiceClient();
                    userDto = client.GetByUserName(userName);
                    if (userDto != null)
                    {
                        CheckMode = mode; // View Mode
                        userRegistrationModel.UserId = userDto.UserId;
                        userRegistrationModel.UserGroupList = userDto.UserWithUserGroups.ToList();
                        userRegistrationModel.BirthDate = userDto.DateOfBirth.ToString("dd/MM/yyyy");
                        Age age = Helper.CalculateAge(userDto.DateOfBirth);
                        //string result = string.Format(ClientResources.URAgeInYearsMonths, age.Years, age.Months);
                        userRegistrationModel.Age = age.Years + " years " + age.Months + " months";
                        userRegistrationModel.UserName = userDto.UserName;
                        userRegistrationModel.Name = userDto.Name;
                        userRegistrationModel.IsActive = userDto.IsActive;
                        userRegistrationModel.MothersMaidenName = userDto.MothersMaidenName;
                        userRegistrationModel.Image = userDto.Image;
                        Session["UploadedImageFileName"] = userDto.Image;
                        userRegistrationModel.Email = userDto.Email;
                        userRegistrationModel.MobileNo = userDto.MobileNo;
                        userRegistrationModel.AllowEdit = userDto.AllowEdit;
                        userRegistrationModel.Title = userDto.Title;
                        userRegistrationModel.CAId = userDto.CAId;
                        if (userDto.UserDesignation != null)
                        {
                            userRegistrationModel.UserDesignation = userDto.UserDesignation;
                            userRegistrationModel.SelectedDesignation = userDto.UserDesignation.DesignationName;
                            //userRegistrationModel.DesignationList.Add(userRegistrationModel.UserDesignation);
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

                                    userRegistrationModel.StateDistrictPlacesControlNames[0].
                                        HiddenFieldForCityVillageValue =
                                        userDto.UserProfile.UserAddress.CityVillage.CityVillageId;
                                    userRegistrationModel.StateDistrictPlacesControlNames[0].HiddenFieldForStateValue =
                                        userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.
                                            StateOfDistrict.StateId;
                                    userRegistrationModel.StateDistrictPlacesControlNames[0].HiddenFieldForDistrictValue =
                                        userDto.UserProfile.UserAddress.CityVillage.DistrictOfCityVillage.DistrictId;
                                }
                            }
                            if (userDto.UserProfile.UserEmergencyContactPerson != null)
                            {
                                userRegistrationModel.UserProfile.UserEmergencyContactPerson =
                                    userDto.UserProfile.UserEmergencyContactPerson;
                                userRegistrationModel.UserProfile.UserEmergencyContactPerson.
                                    UserEmergencyContactPersonId =
                                    userDto.UserProfile.UserEmergencyContactPerson.UserEmergencyContactPersonId;
                                if (userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress != null)
                                {
                                    if (
                                        userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.CityVillage !=
                                        null)
                                    {
                                        userRegistrationModel.UserProfile.UserEmergencyContactPerson.
                                            ContactPersonAddress.
                                            CityVillage.CityVillageId =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.
                                                CityVillage.
                                                CityVillageId;
                                        userRegistrationModel.StateDistrictPlacesControlNames[1].
                                            HiddenFieldForCityVillageValue =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.
                                                CityVillage.CityVillageId;
                                        userRegistrationModel.StateDistrictPlacesControlNames[1].
                                            HiddenFieldForStateValue =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.
                                                CityVillage.DistrictOfCityVillage.StateOfDistrict.StateId;
                                        userRegistrationModel.StateDistrictPlacesControlNames[1].
                                            HiddenFieldForDistrictValue =
                                            userDto.UserProfile.UserEmergencyContactPerson.ContactPersonAddress.
                                                CityVillage.DistrictOfCityVillage.DistrictId;
                                    }
                                }
                                if (userDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser !=
                                    null)
                                {
                                    userRegistrationModel.UserProfile.UserEmergencyContactPerson.
                                        ContactPersonRelationshipWithUser =
                                        userDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser;
                                    userRegistrationModel.UserProfile.UserEmergencyContactPerson.
                                        ContactPersonRelationshipWithUser.RelationshipId =
                                        userDto.UserProfile.UserEmergencyContactPerson.ContactPersonRelationshipWithUser
                                            .RelationshipId;
                                }
                            }
                        }
                        foreach (UserGroupDto ug in userDto.UserWithUserGroups)
                        {
                            userRegistrationModel.SelectedUserGroupList += ug.UserGroupName + " ,\n";
                        }
                        if (!String.IsNullOrEmpty(userRegistrationModel.SelectedUserGroupList))
                            userRegistrationModel.SelectedUserGroupList =
                                userRegistrationModel.SelectedUserGroupList.TrimEnd(',', '\n');
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
            return View("UserRegistrationView", userRegistrationModel);
        }
    }
}

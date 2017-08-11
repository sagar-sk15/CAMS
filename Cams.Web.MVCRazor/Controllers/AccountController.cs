using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Cams.Web.MVCRazor.Models.Account;
using Cams.Web.MVCRazor.UserServiceReference;
using Cams.Common;
using Cams.Common.Dto.User;
using System.Web.Security;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {
        //
        // GET: /LogOn/

        public ActionResult LogOn()
        {
            return View("LogOn");
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            string action = string.Empty;
            string controller = string.Empty;
            UserServiceClient client = null;
            try
            {
                if (ModelState.IsValid)
                {
                    client = new UserServiceClient();
                    UserDto currentUser = client.Login(model.UserName.Trim(), Helper.Encode(model.Password.Trim()));
                    if (currentUser == null)
                    {
                        ModelState.AddModelError("", ClientResources.CredentialsIncorrect);
                    }
                    else if (currentUser.IsOnLine == true && currentUser.Response.HasWarning)
                    {
                        ModelState.AddModelError("", ClientResources.LoggedInWithSameAccount);
                    }
                    else if (currentUser.IsLockedOut)
                    {
                        return RedirectToAction("AccountLocked");
                    }
                    else
                    {
                        var authTicket = new FormsAuthenticationTicket(
                            1,          // version     
                            currentUser.UserName,   // user name     
                            DateTime.Now, // created     
                            DateTime.Now.AddMinutes(20),   // expires     
                            true,  // persistent?     
                            "Moderator;ClientAdmin" // can be used to store roles     
                            );
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        HttpContext.Response.Cookies.Add(authCookie);
                        //HttpContext.Current.Response.Cookies.Add(authCookie); 

                        Session[Constants.SKCURRENTUSER] = currentUser;
                        Session[Constants.SKUSERNAME] = currentUser.UserName;
                        Session[Constants.SKUSERPROFILEIMAGE] = currentUser.Image;
                        if (Helper.IsCAIdNotNull(currentUser))
                        {
                            action = "ClientWelcome";
                            controller = "ClientAccount";
                        }
                        else
                        {
                            action = "Welcome";
                            controller = "Account";
                        }
                    }
                }
                if (!string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(controller))
                {
                    return RedirectToAction(action, controller);
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
            return View(model);
        }

        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Logout()
        {
            UserDto userDto = (UserDto)Session[Constants.SKCURRENTUSER];
            UserServiceClient client = new UserServiceClient();
            //userDto = client.GetByUserName(userDto.UserName);
            //client.Close();
            if (userDto != null)
            {
                userDto.IsOnLine = false;
                userDto.ViewOfUserUserGroupRolePermissions = null;
                
                client.Update(userDto, null);
                client.Close();
            }
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("LogOn");
        }


        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                UserDto currentUserDto = (UserDto)Session[Constants.SKCURRENTUSER];
                //UserServiceClient cl = new UserServiceClient();

                changePasswordModel.CurrentPassword = Helper.Encode(changePasswordModel.CurrentPassword.Trim());
                changePasswordModel.NewPassword = Helper.Encode(changePasswordModel.NewPassword.Trim());
                changePasswordModel.ConfirmNewPassword = Helper.Encode(changePasswordModel.ConfirmNewPassword.Trim());
                UserServiceClient client = null;
                try
                {
                    if (string.Equals(currentUserDto.Password, changePasswordModel.CurrentPassword))
                    {
                        if (string.Equals(changePasswordModel.NewPassword, changePasswordModel.ConfirmNewPassword))
                        {
                            if (!string.Equals(currentUserDto.Password, changePasswordModel.NewPassword))
                            {
                                if (!string.Equals(currentUserDto.LastPassword, changePasswordModel.NewPassword) && !string.Equals(currentUserDto.SecondLastPassword, changePasswordModel.NewPassword))
                                {

                                    currentUserDto.SecondLastPassword = currentUserDto.LastPassword;
                                    currentUserDto.LastPassword = currentUserDto.Password;
                                    currentUserDto.Password = changePasswordModel.NewPassword;
                                    currentUserDto.SecondLastPasswordChangedDate = currentUserDto.LastPasswordChangedDate;
                                    currentUserDto.LastPasswordChangedDate = DateTime.Now;

                                    client = new UserServiceClient();
                                    currentUserDto.ViewOfUserUserGroupRolePermissions = null;
                                    client.Update(currentUserDto,currentUserDto.UserName);
                                    TempData["PasswordChanged"] = ClientResources.PasswordChanged;
                                }
                                else
                                {
                                    ModelState.AddModelError("", ErrorAndValidationMessages.ValidatePasswordWithLastTwoPasswords);
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", ErrorAndValidationMessages.ValidatePasswordWithExistingPassword);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", ErrorAndValidationMessages.ValidatePasswordMatch);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorAndValidationMessages.ValidateExistingPassword);
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
            }
            return View(changePasswordModel);
        }
        public ActionResult ChangePasswordIndex()
        {
            return View("ChangePassword");
        }
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPS, Permissions = CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult Welcome()
        {
            return View("Welcome");
        }

        public ActionResult Error()
        {
            Logout();
            return View("ErrorPage");
        }

        public ActionResult AccountLocked()
        {
            return View("UserAccountLocked");
        }

    }
}

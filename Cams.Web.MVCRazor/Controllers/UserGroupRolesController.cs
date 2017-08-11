using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.Models.Account;
using Cams.Web.MVCRazor.RolesServiceReference;
using Cams.Web.MVCRazor.UserGroupServiceReference;
using Cams.Common;
using Cams.Web.MVCRazor.Helpers;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {
        //
        // GET: /UserGroupRoles/
        [CamsAuthorize(Roles=Constants.MANAGEACKUSERGROUPROLE +","+ Constants.MANAGECLIENTUSERGROUPROLE,
            Permissions=CamsAuthorizeAttribute.RolePermission.View)]
        public ActionResult UserGroupRolesIndex()
        {
            UserGroupRolesModel model = new UserGroupRolesModel();
            UserGroupServiceReference.UserGroupServiceClient UGClient = null;
            try
            {
                string usergroupid = "";
                if (!string.IsNullOrEmpty(Request.QueryString["usergroupid"]))
                {
                    UGClient = new UserGroupServiceClient();
                    usergroupid = Request.QueryString["usergroupid"];
                    UserGroupDto Usergroupdto = UGClient.GetById(Convert.ToInt32(usergroupid));
                    UGClient.Close();
                    model.UserGroupName = Usergroupdto.UserGroupName;
                    model.RoleGroupList = GetRoleGroupList(usergroupid);
                }

                string usertype = "";
                if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
                    usertype = Request.QueryString["userType"];                
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            
            return View("UserGroupRoles", model);
        }

        [CamsAuthorize(Roles = Constants.MANAGEACKUSERGROUPROLE + "," + Constants.MANAGECLIENTUSERGROUPROLE,
            Permissions = CamsAuthorizeAttribute.RolePermission.Update)]
        public ActionResult SaveUserGroupRolePermissions(UserGroupRolesModel model)
        {
            UserGroupServiceReference.UserGroupServiceClient UGClient = null;
            UserGroupDto userGroupDto = new UserGroupDto();
            string[] RoleGroupNames = { string.Empty };
            int usergroupid = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["usergroupid"]))
            {
                usergroupid = Convert.ToInt32(Request.QueryString["usergroupid"]);
            }

            try
            {
                UGClient = new UserGroupServiceClient();
                userGroupDto = UGClient.GetById(usergroupid);
                RoleGroupNames = (string[])Session["RoleGroupNames" + Request.QueryString["usergroupid"]];

                //if (userGroupDto.RolePermissionsInUserGroup == null || userGroupDto.RolePermissionsInUserGroup.Count == 0)
                userGroupDto.RolePermissionsInUserGroup = new List<UserGroupRolePermissionDto>();
                userGroupDto.RolePermissionsInUserGroup.Clear();
                for (int i = 0; i < RoleGroupNames.Count(); i++)
                {
                    List<RoleModel> Roles = (List<RoleModel>)Session[RoleGroupNames[i]];
                    if (Roles != null)
                    {
                        foreach (RoleModel rolemodel in Roles)
                        {
                            if (rolemodel.AllowAdd || rolemodel.AllowEdit || rolemodel.AllowPrint || rolemodel.AllowView || rolemodel.AllowDelete)
                            {
                                var userGroupRolePermissionDto = new UserGroupRolePermissionDto
                                {
                                    PermissionForUserGroup = new List<UserGroupDto>
                                        {
                                            new UserGroupDto
                                            {
                                                UserGroupId = userGroupDto.UserGroupId
                                            }
                                        },
                                    PermissionForRole = rolemodel.PermissionForRole,
                                    AllowAdd = rolemodel.AllowAdd,
                                    AllowEdit = rolemodel.AllowEdit,
                                    AllowView = rolemodel.AllowView,
                                    AllowDelete = rolemodel.AllowDelete,
                                    AllowPrint = rolemodel.AllowPrint
                                };
                                userGroupDto.RolePermissionsInUserGroup.Add(userGroupRolePermissionDto);
                            }
                        }
                    }
                }
                UGClient.Update(userGroupDto, ((UserDto)Session[Constants.SKCURRENTUSER]).UserName);
                UGClient.Close();

            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (RoleGroupNames != null && RoleGroupNames.Count() > 0)
                {
                    for (int i = 0; i < RoleGroupNames.Count(); i++)
                    {
                        Session.Remove(RoleGroupNames[i]);
                    }
                }
                if (Session["RoleGroupNames" + usergroupid] != null)
                Session.Remove("RoleGroupNames" + usergroupid);
            }
            return RedirectToAction("UserGroupsIndex", new { usertype = Request.QueryString["usertype"] });
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Web.MVCRazor.Models.Account;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.UserServiceReference;
using DevExpress.Web.Mvc;
using Cams.Web.MVCRazor.Helpers;
using Cams.Common;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {
        [CamsAuthorize(Roles = Constants.MANAGEACKUSERROLE + "," + Constants.MANAGECLIENTUSERROLE,
            Permissions = CamsAuthorizeAttribute.RolePermission.Update)]
        public ActionResult UserRolesIndex()
        {
            string username = Request.QueryString["username"];
            UserServiceReference.UserServiceClient client = new UserServiceClient();
            UserDto user = client.GetByUserName(username);
            client.Close();

            ParentUserRolesModel parentUserRolesModel = new ParentUserRolesModel();
            parentUserRolesModel.UserGroupsString = string.Join(",", user.UserWithUserGroups.Select(x => x.UserGroupName).ToArray());

            parentUserRolesModel.UserRoleModelList = GetUserRoles(user.UserWithRolePermissions);
            parentUserRolesModel.UserRoleDtoList = GetRoleGroupList(string.Empty);
            Session["UserRolesModelList" + username] = parentUserRolesModel.UserRoleModelList;
            if (parentUserRolesModel.UserRoleModelList.Count == 0)
                Session["UserRolesModelList" + username] = parentUserRolesModel.UserRoleModelList = AddRowToUserRolePermissions(username);
            
            return View("UserRoles", parentUserRolesModel);
        }

        private IList<UserRolesModel> GetUserRoles(IList<UserRolePermissionDto> userRolePermissionDtos)
        {
            IList<UserRolesModel> userRolesModels = new List<UserRolesModel>();
            int urpId = 0;
            foreach (UserRolePermissionDto userRolePermissionDto in userRolePermissionDtos)
            {
                UserRolesModel userRolesModel = new UserRolesModel
                                                    {
                                                        AllowAdd = userRolePermissionDto.AllowAdd,
                                                        AllowDelete = userRolePermissionDto.AllowDelete,
                                                        AllowEdit = userRolePermissionDto.AllowEdit,
                                                        AllowPrint = userRolePermissionDto.AllowPrint,
                                                        AllowView = userRolePermissionDto.AllowView,
                                                        UserRoleDto = userRolePermissionDto.PermissionForRole,
                                                        UserRolePermissionId = ++urpId
                                                    };
                userRolesModels.Add(userRolesModel);

            }

            return userRolesModels;
        }

        [CamsAuthorize(Roles = Constants.MANAGEACKUSERROLE + "," + Constants.MANAGECLIENTUSERROLE,
           Permissions = CamsAuthorizeAttribute.RolePermission.Update)]
        [HttpPost]
        public ActionResult SaveUserRolePermissions()
        {
            string username = Request.QueryString["username"];
            UserServiceReference.UserServiceClient client = new UserServiceClient();
            try
            {
                UserDto user = client.GetByUserName(username);

                IList<UserRolesModel> userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];
                user.UserWithRolePermissions = new List<UserRolePermissionDto>();
                user.UserWithRolePermissions.Clear();
                foreach (UserRolesModel urmodel in userRoleModelList)
                {
                    if (urmodel.AllowAdd || urmodel.AllowEdit || urmodel.AllowPrint || urmodel.AllowView || urmodel.AllowDelete)
                    {
                        UserRolePermissionDto URPDto = new UserRolePermissionDto()
                                                            {
                                                                PermissionForRole = urmodel.UserRoleDto,
                                                                AllowAdd = urmodel.AllowAdd,
                                                                AllowDelete = urmodel.AllowDelete,
                                                                AllowEdit = urmodel.AllowEdit,
                                                                AllowPrint = urmodel.AllowPrint,
                                                                AllowView = urmodel.AllowView,
                                                            };
                        user.UserWithRolePermissions.Add(URPDto);
                    }
                }
                user.ViewOfUserUserGroupRolePermissions = null;
                user = client.Update(user, ((UserDto)Session[Constants.SKCURRENTUSER]).UserName);
            }
            catch (Exception ex)
            {
                return View("ErrorPage");
            }
            finally
            {
                if (Session["UserRolesModelList" + username] != null)
                    Session.Remove("UserRolesModelList" + username);
            }
            return RedirectToAction("UsersIndex", new { usertype = Request.QueryString["usertype"] });
        }

        public ActionResult UpdateUserRoleValue(string fieldName, int userRolePermissionId, bool value)
        {
            IList<UserRolesModel> userRoleModelList = new List<UserRolesModel>();
            string username = Request.Params["username"];
            if (Session["UserRolesModelList" + username] != null)
            {
                userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];
                UserRolesModel userRolesModel =
                    userRoleModelList.Where(f => f.UserRolePermissionId == userRolePermissionId).First();
                switch (fieldName)
                {
                    case "AllowAdd":
                        userRolesModel.AllowAdd = value;
                        break;
                    case "AllowEdit":
                        userRolesModel.AllowEdit = value;
                        break;
                    case "AllowDelete":
                        userRolesModel.AllowDelete = value;
                        break;
                    case "AllowView":
                        userRolesModel.AllowView = value;
                        break;
                    case "AllowPrint":
                        userRolesModel.AllowPrint = value;
                        break;
                }
                Session["UserRolesModelList" + username] = userRoleModelList;
            }

            return PartialView("UserRolesGrid", userRoleModelList);
        }

        public JsonResult GetRolePermissions()
        {
            string username = Request.Params["username"];
            UserRolesModel userRolesModel = new UserRolesModel();
            IList<UserRolesModel> userRoleModelList = new List<UserRolesModel>();
            IDictionary<string, string> UserRolePermissions = new Dictionary<string, string>();

            int roleId = 0, urpId=0;

            if (Request.Params["item"] != null)
                roleId = Convert.ToInt32(Request.Params["item"]);
            if (Request.Params["urpId"] != null)
                urpId = Convert.ToInt32(Request.Params["urpId"]);

            userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];

            var res = userRoleModelList.Where(x => (x.UserRoleDto != null && x.UserRoleDto.RoleId == roleId));
            if (res.Count() != 0)
            {
                UserRolePermissions.Add("RoleAlreadyExist", "True");
            }
            else
            {
                RolesServiceReference.RoleServiceClient client = new RolesServiceReference.RoleServiceClient();
                userRolesModel.UserRoleDto = client.GetById(roleId);
                client.Close();

                UserRolePermissions.Add("IsAddApplicable", userRolesModel.UserRoleDto.IsAddApplicable.ToString());
                UserRolePermissions.Add("IsEditApplicable", userRolesModel.UserRoleDto.IsEditApplicable.ToString());
                UserRolePermissions.Add("IsViewApplicable", userRolesModel.UserRoleDto.IsViewApplicable.ToString());
                UserRolePermissions.Add("IsDeleteApplicable", userRolesModel.UserRoleDto.IsDeleteApplicable.ToString());
                UserRolePermissions.Add("IsPrintApplicable", userRolesModel.UserRoleDto.IsPrintApplicable.ToString());

                userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];
                res = userRoleModelList.Where(x => x.UserRolePermissionId == urpId);
                if (res.Count() != 0)
                {
                    res.First().UserRoleDto = userRolesModel.UserRoleDto;
                    Session["UserRolesModelList"] = userRoleModelList;
                }
            }
            return Json(UserRolePermissions, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult AddRowUserRolePermissions()
        //{
        //    ParentUserRolesModel parentUserRolesModel = (ParentUserRolesModel)Session["UserRolesModelList"];
        //    int urpId = 0;
        //    urpId = parentUserRolesModel.UserRoleModelList.Count == 0 ? urpId : (parentUserRolesModel.UserRoleModelList.Last().UserRolePermissionId);
        //    UserRolesModel newUserRolesModel = new UserRolesModel();
        //    newUserRolesModel.UserRolePermissionId = ++urpId;
        //    parentUserRolesModel.UserRoleModelList.Add(newUserRolesModel);
        //    return View("UserRoles", parentUserRolesModel);
        //}

        public IList<UserRolesModel> AddRowToUserRolePermissions(string username)
        {
            //string username = Request.Params["username"];
            IList<UserRolesModel> userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];
            int urpId = 0;
            urpId = userRoleModelList.Count == 0 ? urpId : (userRoleModelList.Last().UserRolePermissionId);
            UserRolesModel newUserRolesModel = new UserRolesModel();
            newUserRolesModel.UserRolePermissionId = ++urpId;
            userRoleModelList.Add(newUserRolesModel);
            return userRoleModelList;
        }

        public IList<UserRolesModel> DeleteRowFromUserRolePermissions(int urpId)
        {
            string username = Request.Params["username"];
            IList<UserRolesModel> userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];
            //int urpId = 0;
            //urpId = parentUserRolesModel.UserRoleModelList.Count == 0 ? urpId : (parentUserRolesModel.UserRoleModelList.Last().UserRolePermissionId);
            var res = userRoleModelList.Where(x => x.UserRolePermissionId == urpId);
            if (res.Count() != 0)
            {
                UserRolesModel deleteUserRolesModel = res.First();
                userRoleModelList.Remove(deleteUserRolesModel);
            }
            return userRoleModelList;
        }

        
        public ActionResult UserRolePermissionsGrid()
        {
            //string addNewRole = Request.Params["AddNewRole"];
            string username = Request.Params["username"];
            bool addNewRole = Request.Params["DXCallbackArgument"].Split('|').Contains("AddNewRole;");
            IList<UserRolesModel> userRoleModelList = new List<UserRolesModel>();
            userRoleModelList = (IList<UserRolesModel>)Session["UserRolesModelList" + username];
            if (addNewRole)
            {
                userRoleModelList = AddRowToUserRolePermissions(username);
            }
            var res = Request.Params["DXCallbackArgument"].Split('|').ToArray().Where(x=>x.StartsWith("DeleteRole"));
            string delRoleKey ="";
            if (res.Count() != 0)
            {
                delRoleKey = res.First().Replace("DeleteRole", "");
                delRoleKey =delRoleKey.TrimEnd(';');
                userRoleModelList = DeleteRowFromUserRolePermissions(Convert.ToInt32(delRoleKey));
            }
            var sordesc = userRoleModelList.OrderByDescending(x => x.UserRolePermissionId);
            userRoleModelList = sordesc.ToList();
            return PartialView("UserRolesGrid", userRoleModelList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.RolesServiceReference;
using Cams.Web.MVCRazor.Models.Account;

namespace Cams.Web.MVCRazor.Controllers
{
    public partial class AccountController : CommonController
    {
        RolesServiceReference.RoleServiceClient client = null;

        //[System.Web.Mvc.OutputCache(NoStore =true, Duration = 0, VaryByParam = "*")]
        #region Common Actions
        public ActionResult GetRolesList(string RoleGroup)
        {
            IList<RoleModel> roleList = new List<RoleModel>();
            string userGroupid = string.Empty;
            string PartialViewName = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["usergroupid"]))
            {
                userGroupid = Request.Params["usergroupid"];
                roleList = GetRoles(RoleGroup, userGroupid);
                PartialViewName = "RolesGrid";
            }
            string username = string.Empty;
            if (!string.IsNullOrEmpty(Request.Params["username"]))
            {
                username = Request.Params["username"];
                roleList = GetAssignedRoles(RoleGroup, username);
                PartialViewName = "RolesGridReadOnly";
            }
            ViewData["RoleGroup"] = RoleGroup;
            return PartialView(PartialViewName, roleList);
        }

        public ActionResult GetRoleGroups()
        {
            string usergroupid = "";
            string PartialViewName = string.Empty;
            IList<RoleDto> Roles = new List<RoleDto>();
            if (!string.IsNullOrEmpty(Request.Params["usergroupid"]))
            {
                usergroupid = Request.Params["usergroupid"];
                Roles = GetRoleGroupList(usergroupid);
                PartialViewName = "RoleGroupsGrid";
            }
            else
            {
                Roles = GetRoleGroupList(string.Empty);
                PartialViewName = "RoleGroupGridReadOnly";
            }
            return PartialView(PartialViewName, Roles);
        }

        public List<RoleDto> GetRoleGroupList(string usergroupId)
        {
            Query query = new Query();
            IList<RoleDto> Roles = new List<RoleDto>();
            client = new RoleServiceClient();
            if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
            {
                string usertype = Request.QueryString["userType"];
                if (usertype == "CAUser")
                {
                    Criterion CriteriaIsApplicableForAckUsers = new Criterion("IsApplicableForAckUsers", false, CriteriaOperator.Equal);
                    query.Add(CriteriaIsApplicableForAckUsers);
                }
            }
            var roles = client.FindByQuery(query).Entities.AsEnumerable();
            var roleGroups = roles.GroupBy(p => p.RoleGroup).Select(g => g.First());
            Roles = roleGroups.ToList();
            string[] RoleGroupNames = new string[Roles.Count];
            int i = 0;
            if (!string.IsNullOrEmpty(usergroupId))
            {
                foreach (RoleDto role in Roles)
                {
                    RoleGroupNames[i++] = role.RoleGroup + usergroupId;
                }
                Session["RoleGroupNames" + usergroupId] = RoleGroupNames;
            }
            return roleGroups.ToList();
        }
        #endregion

        #region UserGroupRoles
        public List<RoleModel> GetRoles(string roleGroup, string userGroupid)
        {
            List<RoleModel> roleModelList = new List<RoleModel>();

            if (Session[roleGroup + userGroupid] == null)
            {
                Query query = new Query();
                IList<RoleDto> Roles = new List<RoleDto>();
                client = new RoleServiceClient();

                UserGroupServiceReference.UserGroupServiceClient UGClient = null;
                UserGroupDto userGroupDto = new UserGroupDto();
                UGClient = new UserGroupServiceReference.UserGroupServiceClient();
                userGroupDto = UGClient.GetById(Convert.ToInt32(userGroupid));

                if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
                {
                    string usertype = Request.QueryString["userType"];
                    if (usertype == "CAUser")
                    {
                        Criterion CriteriaIsApplicableForAckUsers = new Criterion("IsApplicableForAckUsers", false, CriteriaOperator.Equal);
                        query.Add(CriteriaIsApplicableForAckUsers);
                    }
                }
                Criterion CriteriaRoleGroup = new Criterion("RoleGroup", roleGroup, CriteriaOperator.Equal);
                query.Add(CriteriaRoleGroup);
                Roles = client.FindByQuery(query).Entities.ToList();

                int RolePermissionId = 0;
                bool allowAdd, allowEdit, allowView, allowPrint, allowDelete;

                foreach (RoleDto role in Roles)
                {
                    allowAdd = allowEdit = allowView = allowPrint = allowDelete = false;
                    var ugrolelist = userGroupDto.RolePermissionsInUserGroup.Where(x => x.PermissionForRole.RoleId == role.RoleId);

                    UserGroupRolePermissionDto urpDto = null;
                    if (ugrolelist.Count() != 0)
                        urpDto = ugrolelist.First();
                    if (urpDto != null)
                    {
                        allowAdd = urpDto.AllowAdd;
                        allowEdit = urpDto.AllowEdit;
                        allowDelete = urpDto.AllowDelete;
                        allowPrint = urpDto.AllowPrint;
                        allowView = urpDto.AllowView;
                    }
                    roleModelList.Add(new RoleModel
                    {
                        RolePermissionId = ++RolePermissionId,
                        PermissionForRole = role,
                        AllowAdd = allowAdd,
                        AllowEdit = allowEdit,
                        AllowDelete = allowDelete,
                        AllowPrint = allowPrint,
                        AllowView = allowView
                    });
                }
                Session[roleGroup + userGroupid] = roleModelList;
            }
            else
            {
                roleModelList = (List<RoleModel>)Session[roleGroup + userGroupid];
            }
            return roleModelList;
        }

        public ActionResult UpdateRoleValue(string fieldName, long rolePermissionId, int roleId, string roleGroup, int userGroupId, bool value)
        {
            string userGroupid = userGroupId.ToString();
            if (Session[roleGroup + userGroupid] != null)
            {
                List<RoleModel> Roles = (List<RoleModel>)Session[roleGroup + userGroupid];
                RoleModel Role = Roles.First(f => f.RolePermissionId == rolePermissionId);
                switch (fieldName)
                {
                    case "AllowAdd":
                        Role.AllowAdd = value;
                        break;
                    case "AllowEdit":
                        Role.AllowEdit = value;
                        break;
                    case "AllowDelete":
                        Role.AllowDelete = value;
                        break;
                    case "AllowView":
                        Role.AllowView = value;
                        break;
                    case "AllowPrint":
                        Role.AllowPrint = value;
                        break;
                }
                Session[roleGroup + userGroupid] = Roles;
            }
            return PartialView("RolesGrid");
        }
        #endregion

        #region UserRoles
        public List<RoleModel> GetAssignedRoles(string roleGroup, string UserName)
        {
            List<RoleModel> roleModelList = new List<RoleModel>();

            Query query = new Query();
            IList<RoleDto> Roles = new List<RoleDto>();
            client = new RoleServiceClient();
            
            
            UserServiceReference.UserServiceClient UserClient = null;
            UserDto userDto = new UserDto();
            UserClient = new UserServiceReference.UserServiceClient();
            userDto = UserClient.GetByUserName(UserName);

            if (!string.IsNullOrEmpty(Request.QueryString["userType"]))
            {
                string usertype = Request.QueryString["userType"];
                if (usertype == "CAUser")
                {
                    Criterion CriteriaIsApplicableForAckUsers = new Criterion("IsApplicableForAckUsers", false, CriteriaOperator.Equal);
                    query.Add(CriteriaIsApplicableForAckUsers);
                }
            }
            Criterion CriteriaRoleGroup = new Criterion("RoleGroup", roleGroup, CriteriaOperator.Equal);
            query.Add(CriteriaRoleGroup);
            Roles = client.FindByQuery(query).Entities.ToList();

            int RolePermissionId = 0;
            bool allowAdd, allowEdit, allowView, allowPrint, allowDelete;

            foreach (RoleDto role in Roles)
            {
                allowAdd = allowEdit = allowView = allowPrint = allowDelete = false;
                var ugrolelist = userDto.ViewOfUserUserGroupRolePermissions.Where(x => x.PermissionForRole.RoleId == role.RoleId);

                viewUserUserGroupRolePermissionsDto viewUUGRPDto = null;
                if (ugrolelist.Count() != 0)
                    viewUUGRPDto = ugrolelist.First();
                if (viewUUGRPDto != null)
                {
                    allowAdd = viewUUGRPDto.AllowAdd;
                    allowEdit = viewUUGRPDto.AllowEdit;
                    allowDelete = viewUUGRPDto.AllowDelete;
                    allowPrint = viewUUGRPDto.AllowPrint;
                    allowView = viewUUGRPDto.AllowView;
                }
                roleModelList.Add(new RoleModel
                {
                    RolePermissionId = ++RolePermissionId,
                    PermissionForRole = role,
                    AllowAdd = allowAdd,
                    AllowEdit = allowEdit,
                    AllowDelete = allowDelete,
                    AllowPrint = allowPrint,
                    AllowView = allowView
                });
            }
            return roleModelList;
        }
        #endregion
    }
}

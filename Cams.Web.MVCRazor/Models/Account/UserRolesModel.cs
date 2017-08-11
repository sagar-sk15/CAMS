using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Web.MVCRazor.RolesServiceReference;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class UserRolesModel
    {
        public UserRolesModel()
        {
            ++UserRolePermissionId;
        }

        public RoleDto UserRoleDto { get; set; }
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
        public virtual int UserRolePermissionId { get; set; }

        public static IList<RoleDto> GetAllRoles(string userType)
        {
            RolesServiceReference.RoleServiceClient client = null;
            IList<RoleDto> Roles = new List<RoleDto>();
            Query query = new Query();
            client = new RoleServiceClient();
                if (userType== "CAUser")
                {
                    Criterion CriteriaIsApplicableForAckUsers = new Criterion("IsApplicableForAckUsers", false, CriteriaOperator.Equal);
                    query.Add(CriteriaIsApplicableForAckUsers);
                }
            
            Roles = client.FindByQuery(query).Entities.ToList();
            client.Close();
            //Session["UsersRolesList"] = Roles;
            return Roles;
        }
    }

    public class ParentUserRolesModel
    {
        public ParentUserRolesModel()
        {
            UserRoleDtoList = new List<RoleDto>();
            UserRoleModelList = new List<UserRolesModel>();
            UserRoleModelList.Add(new UserRolesModel());
            RoleModelList = new List<RoleModel>();
        }
        public IList<RoleDto> UserRoleDtoList;
        public IList<RoleModel> RoleModelList;
        public IList<UserRolesModel> UserRoleModelList;
        public UserGroupRolesModel UserGroupRoles;
        public string UserGroupsString;
    }
}
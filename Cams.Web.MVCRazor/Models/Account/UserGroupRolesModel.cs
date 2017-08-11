using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class UserGroupRolesModel 
    {
        public UserGroupRolesModel()
        {
            RoleList = new List<RoleModel>();
            RoleGroupList = new List<RoleDto>();
            UserGroupName = string.Empty;
        }
        public IList<RoleModel> RoleList;
        public IList<RoleDto> RoleGroupList;
        public string UserGroupName;
    }
}
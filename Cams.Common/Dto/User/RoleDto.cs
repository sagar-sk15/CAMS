using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.User
{
    /// <summary>
    /// This class is used transfer the Role data objects between the different layers.
    /// </summary>
    public class RoleDto : DtoBase
    {
        public RoleDto()
        {
            RolesInUserRolePermissions = new List<UserRolePermissionDto>();
            RolesInUserGroupRolePermissions = new List<UserGroupRolePermissionDto>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual string RoleGroup { get; set; }
        public virtual bool IsApplicableForAckUsers { get; set; }
        public bool IsAddApplicable { get; set; }
        public bool IsEditApplicable { get; set; }
        public bool IsViewApplicable { get; set; }
        public bool IsDeleteApplicable { get; set; }
        public bool IsPrintApplicable { get; set; }
        //public IList<UserDto> RolesInUserRolePermissions { get; set; }
        public virtual IList<UserRolePermissionDto> RolesInUserRolePermissions { get; set; }
        public IList<UserGroupRolePermissionDto> RolesInUserGroupRolePermissions { get; set; }
    }
}

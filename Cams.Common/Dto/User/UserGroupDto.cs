using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.User
{
    public class UserGroupDto : DtoBase
    {
        public UserGroupDto()
        {
            UsersInUserGroup = new List<UserDto>();
            RolePermissionsInUserGroup = new List<UserGroupRolePermissionDto>();
        }
        public virtual int UserGroupId { get; set; }
        public virtual string UserGroupName { get; set; }
        public virtual string Description { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual IList<UserDto> UsersInUserGroup { get; set; }
        public virtual IList<UserGroupRolePermissionDto> RolePermissionsInUserGroup { get; set; }
        public virtual int UsersInUserGroupCount { get; set; }
        public virtual int RolesInUserGroupCount { get; set; }
    }
}

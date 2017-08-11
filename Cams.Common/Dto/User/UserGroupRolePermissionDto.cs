using System;
using System.Linq;
using Cams.Common.Message;
using System.Collections.Generic;

namespace Cams.Common.Dto.User
{
    public class UserGroupRolePermissionDto : DtoBase
    {
        public UserGroupRolePermissionDto()
        {
            PermissionForUserGroup = new List<UserGroupDto>();
        }
        public virtual long UserGroupRolePermissionId { get; set; }
        public virtual IList<UserGroupDto> PermissionForUserGroup { get; set; }
        public virtual RoleDto PermissionForRole { get; set; }
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
    }
}

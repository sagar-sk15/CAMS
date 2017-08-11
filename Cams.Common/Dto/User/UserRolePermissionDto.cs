using System;
using System.Linq;
using Cams.Common.Message;
using System.Collections.Generic;

namespace Cams.Common.Dto.User
{
    public class UserRolePermissionDto : DtoBase
    {
        public UserRolePermissionDto()
        {
            //PermissionForUser = new UserDto();
            //PermissionForRole = new RoleDto();
            PermissionForUser = new List<UserDto>();
        }
        public virtual long UserRolePermissionId { get; set; }
        //public UserDto PermissionForUser { get; set; }
        public virtual IList<UserDto> PermissionForUser { get; set; }
        public virtual RoleDto PermissionForRole { get; set; }
        //public long UserId { get; set; }
        //public int RoleId { get; set; }
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
    }
}

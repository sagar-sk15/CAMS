using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;

namespace Cams.Web.MVCRazor.Models.Account 
{
    public class RoleModel //: UserGroupRolePermissionDto 
    {
        public RoleModel()
        {
            //PermissionForRole = new RoleDto();
        }
        public virtual RoleDto PermissionForRole { get; set; }
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
        public virtual long RolePermissionId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.User
{
    public class viewUserUserGroupRolePermissionsDto : DtoBase
    {
        #region Constructor
        public viewUserUserGroupRolePermissionsDto()
        {
        }
        #endregion 

        #region Properties
        //public virtual int UserID { get; set; }
        //public virtual string UserName { get; set; }
        //public virtual int RoleId { get; set; }
        public virtual RoleDto PermissionForRole { get; set; }
        public virtual UserDto RolePermissionsOfUser { get; set; }
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
        #endregion
    }
}

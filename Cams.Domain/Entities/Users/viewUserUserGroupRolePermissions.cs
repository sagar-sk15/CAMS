using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Users
{
    public class viewUserUserGroupRolePermissions : EntityBase<int>
    {
        #region Constructor
        public viewUserUserGroupRolePermissions()
        {
        }
        #endregion 

        #region Properties
        //public virtual int UserID { get; set; }
        //public virtual string UserName { get; set; }
        //public virtual int RoleId { get; set; }
        public virtual int AllowAdd { get; set; }
        public virtual int AllowEdit { get; set; }
        public virtual int AllowView { get; set; }
        public virtual int AllowDelete { get; set; }
        public virtual int AllowPrint { get; set; }
        public virtual Role PermissionForRole { get; set; }
        public virtual User RolePermissionsOfUser { get; set; }
        #endregion

        #region methods
        public override void Validate()
        {
            return;
        }
        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode = hashCode ^ PermissionForRole.RoleId.GetHashCode() ^ RolePermissionsOfUser.UserId.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var toCompare = obj as viewUserUserGroupRolePermissions;
            if (toCompare == null)
            {
                return false;
            }
            return (this.GetHashCode() != toCompare.GetHashCode());
        } 
        #endregion 
    }
}

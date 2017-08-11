using System.Collections.Generic; 
using System;

namespace Cams.Domain.Entities.Users 
{
    /// <summary>
    /// The Roles are default entries in database so are readonly.
    /// </summary>
    public class Role : EntityBase<int>
    {
        #region Constructor
        public Role()
        {
            RolesInUserRolePermissions = new List<UserRolePermission>();
            RolesInUserGroupRolePermissions = new List<UserGroupRolePermission>();
        }
        #endregion 

        #region properties

        public virtual int RoleId { get; protected set; }
        public virtual string RoleName { get; protected set; }
        public virtual string RoleGroup { get; set; }
        public virtual bool IsApplicableForAckUsers { get; set; }
        public virtual bool IsAddApplicable { get; protected set; }
        public virtual bool IsEditApplicable { get; protected set; }
        public virtual bool IsViewApplicable { get; protected set; }
        public virtual bool IsDeleteApplicable { get; protected set; }
        public virtual bool IsPrintApplicable { get; protected set; }
        public virtual IList<UserRolePermission> RolesInUserRolePermissions { get; set; }
        public virtual IList<UserGroupRolePermission> RolesInUserGroupRolePermissions { get; set; }
        #endregion

        #region methods

        public override void Validate()
        {
            return;
        }            


        #endregion
    }
}

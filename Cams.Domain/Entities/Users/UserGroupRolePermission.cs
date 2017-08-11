using System;
using System.Collections.Generic;

namespace Cams.Domain.Entities.Users
{
    public class UserGroupRolePermission : EntityBase<long>
    {
        #region Constructor
        public UserGroupRolePermission() 
        {
            PermissionForUserGroup = new List<UserGroup>();
        }
        #endregion 

        #region Properties
        public virtual long UserGroupRolePermissionId { get; set; }
        public virtual IList<UserGroup> PermissionForUserGroup { get; set; }
        public virtual Role PermissionForRole { get; set; }
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
        #endregion

        #region Methods
        public override void Validate()
        {
            return;
        }            
               
        #endregion 
    }
}

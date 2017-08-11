using System;
using System.Collections.Generic;


namespace Cams.Domain.Entities.Users
{
    public class UserRolePermission : EntityBase<long>
    {
        #region Constructor
        public UserRolePermission()
        {
            PermissionForUser = new List<User>();
        }
        #endregion 

        #region Properties
        public virtual long UserRolePermissionId { get; set; }
        public virtual IList<User> PermissionForUser { get; set; } 
        public virtual Role PermissionForRole { get; set; }
       
        public virtual bool AllowAdd { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowView { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowPrint { get; set; }
        #endregion 

        #region methods
        public override void Validate()
        {
            return;
        }             

        
        #endregion 
    }
}

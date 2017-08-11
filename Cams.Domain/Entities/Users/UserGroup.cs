using System;
using System.Collections.Generic;
using Cams.Common.Dto.User;
using System.Collections.ObjectModel;

namespace Cams.Domain.Entities.Users
{

    public class UserGroup : EntityBase<int>
    {
        #region Constructor
        public UserGroup()
        {
            _usersInUserGroup = new List<User>();
            RolePermissionsInUserGroup= new List<UserGroupRolePermission>();
        }
        #endregion

        #region Properties
        private IList<User> _usersInUserGroup; 
        public virtual int UserGroupId { get; set; }        
        public virtual string UserGroupName { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<int> CAId { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        //public virtual IList<User> UsersInUserGroup { get; set; }
        public virtual IList<User> UsersInUserGroup { get { return new ReadOnlyCollection<User>(_usersInUserGroup); } }
        public virtual IList<UserGroupRolePermission> RolePermissionsInUserGroup { get; set; }
        #endregion

        #region Methods
        public override void Validate()
        {
            if (String.IsNullOrEmpty(UserGroupName))
            {
                base.AddBrokenRule(UserGroupBusinessRules.UserGroupNameRequired);
                base.IsValidForBasicMandatoryFields = false;
            }
            return;
        }
        #endregion

        public static UserGroupDto UserGroupToUserGroupDto(UserGroup userGroup)
        {
            UserGroupDto ugDto = new UserGroupDto();
            /// mapper
            return ugDto;
        }
    }
}

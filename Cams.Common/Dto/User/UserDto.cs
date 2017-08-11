using System;
using System.Collections.Generic;
using System.Linq;
using Cams.Common.Message;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.Dto.User
{
    public class UserDto : DtoBase
    {
        public UserDto()
        {
            UserWithUserGroups = new List<UserGroupDto>();
            //UserDesignation = new DesignationDto();
            UserWithRolePermissions = new List<UserRolePermissionDto>();
            ViewOfUserUserGroupRolePermissions = new List<viewUserUserGroupRolePermissionsDto>();
            AccountManagerOfClients = new List<ClientDto>();
            DateTime sqlDefaultDate = Helper.SetDefaultDate();
            DateOfBirth = sqlDefaultDate;
            LastActivityDate = sqlDefaultDate;
            LastLockedOutDate = sqlDefaultDate;
            LastLoginDate = sqlDefaultDate;
            LastPasswordChangedDate = sqlDefaultDate;
            SecondLastPasswordChangedDate = sqlDefaultDate;
            FailedPasswordAttemptWindowStart = sqlDefaultDate;
        }

        public virtual IList<UserGroupDto> UserWithUserGroups { get; set; }
        public virtual DesignationDto UserDesignation { get; set; }
        public virtual IList<UserRolePermissionDto> UserWithRolePermissions { get; set; }
        public virtual UserProfileDto UserProfile { get; set; }
        public virtual IList<viewUserUserGroupRolePermissionsDto> ViewOfUserUserGroupRolePermissions { get; set; }
        public virtual ClientDto UserOfClient { get; set; }
        public virtual IList<ClientDto> AccountManagerOfClients { get; set; }  
        public virtual long UserId { get; set; }
        public virtual string UserName { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string CountryCode { get; set; }
        public virtual string MobileNo { get; set; }
        public virtual string MothersMaidenName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsOnLine { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Image { get; set; }
        public virtual string UserType { get; set; }
        public virtual DateTime LastActivityDate { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
        public virtual DateTime LastLockedOutDate { get; set; }
        public virtual System.Nullable<int> FailedPasswordAttemptCount { get; set; }
        public virtual System.Nullable<System.DateTime> FailedPasswordAttemptWindowStart { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Password { get; set; }
        public virtual string LastPassword { get; set; }
        public virtual string SecondLastPassword { get; set; }
        public virtual System.Nullable<System.DateTime> LastPasswordChangedDate { get; set; }
        public virtual System.Nullable<System.DateTime> SecondLastPasswordChangedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool AllowDelete { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual int UserRolesCount { get; set; }
        public virtual int UserGroupsCount { get; set; }

    }
}

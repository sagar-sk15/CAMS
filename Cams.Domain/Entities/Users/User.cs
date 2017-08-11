using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Repository;
using Cams.Common.Dto.User;
using AutoMapper;
using Cams.Common;
using Cams.Domain.Services;
using System.Collections.ObjectModel;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities.Users
{
    public class User : EntityBase<long>
    {
        #region Constructor
        public User()
        {
            UserWithRolePermissions = new List<UserRolePermission>();
            UserWithUserGroups = new List<UserGroup>();
            _viewOfUserUserGroupRolePermissions = new List<viewUserUserGroupRolePermissions>();
            AccountManagerOfClients = new List<Client>();
        }
        #endregion

        #region Properties
        private IList<viewUserUserGroupRolePermissions> _viewOfUserUserGroupRolePermissions;
        public virtual long UserId { get; set; }
        public virtual IList<UserRolePermission> UserWithRolePermissions { get; set; }
        public virtual IList<UserGroup> UserWithUserGroups { get; set; }
        public virtual IList<viewUserUserGroupRolePermissions> ViewOfUserUserGroupRolePermissions { get { return new ReadOnlyCollection<viewUserUserGroupRolePermissions>(_viewOfUserUserGroupRolePermissions); } }
        public virtual Client UserOfClient { get; set; }
        public virtual IList<Client> AccountManagerOfClients { get; set; }    
        public virtual Designation UserDesignation { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual string Username { get; set; }
        public virtual string Title { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string MobileNo { get; set; }
        public virtual string Password { get; set; }
        public virtual string MothersMaidenName { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual string CountryCode { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual System.DateTime DateOfBirth { get; set; }
        public virtual string Image { get; set; }
        public virtual string UserType { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual System.DateTime FailedPasswordAttemptWindowStart { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual bool IsOnLine { get; set; }
        public virtual System.DateTime LastActivityDate { get; set; }
        public virtual System.DateTime LastLockedOutDate { get; set; }
        public virtual System.DateTime LastLoginDate { get; set; }
        public virtual System.DateTime LastPasswordChangedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string LastPassword { get; set; }
        public virtual string SecondLastPassword { get; set; }
        public virtual System.DateTime SecondLastPasswordChangedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual bool AllowDelete { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Validates the user for different businessrules
        /// </summary>
        public override void Validate()
        {
            if (String.IsNullOrEmpty(Username))
            {
                base.AddBrokenRule(UserBusinessRules.UsernameRequired);
                base.IsValidForBasicMandatoryFields = false;
            }
            if (String.IsNullOrEmpty(Password))
                base.AddBrokenRule(UserBusinessRules.PasswordRequired);

            if (!new EmailValidationSpecification().IsSatisfiedBy(Email))
                base.AddBrokenRule(UserBusinessRules.EmailRequired);

            if (String.IsNullOrEmpty(Name))
                base.AddBrokenRule(UserBusinessRules.Name);

            if (String.IsNullOrEmpty(MothersMaidenName))
                base.AddBrokenRule(UserBusinessRules.MothersMaidenName);

            if (String.IsNullOrEmpty(MobileNo))
                base.AddBrokenRule(UserBusinessRules.MobileNo);

            if (String.IsNullOrEmpty(DateOfBirth.ToString()))
                base.AddBrokenRule(UserBusinessRules.DateOfBirth);
        }

        /// <summary>
        /// Check the user is superadmin or not
        /// </summary>
        /// <returns></returns>
        private bool IsSuperAdmin()
        {
            bool result = false;
            if (this.Username.Equals(Constants.SUPERADMINUSER) && !IsCAIdNotNull(this))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Check the user is client admin or not
        /// </summary>
        /// <returns></returns>
        private bool IsClientAdmin()
        {
            bool result = false;
            // var gpresult = UserWithUserGroups.Select(s => s.UserGroupName == Constants.CLIENTADMINGROUP);
            var UG = from x in UserWithUserGroups
                     where x.UserGroupName.Equals(Constants.CLIENTADMINGROUP)
                     select x;
            if (UG.Count() != 0)
            {
                result = true;
            }
            return result;
        }

        #endregion

        public static UserDto UserToUserDto(User user)
        {
            UserDto userDto = Mapper.Map<User, UserDto>(user);
            userDto.UserWithUserGroups.Clear();
            foreach (UserGroup userGroup in user.UserWithUserGroups)
            {
                UserGroupDto ugDto;
                if (userGroup.UserGroupId != 0)
                {
                    UserGroupService ugService = new UserGroupService();
                    ugDto = ugService.GetById(userGroup.UserGroupId);
                }
                else
                    ugDto = UserGroup.UserGroupToUserGroupDto(userGroup);

                userDto.UserWithUserGroups.Add(ugDto);
            }


            //districtDto.StateOfDistrict = State.
            return userDto;
        }

        public static bool IsCAIdNotNull(User Users)
        {
            return (Users.CAId != null) ? ((Users.CAId != 0) ? true : false): false;
            //return (Users.UserOfClient != null) ? (Users.UserOfClient.CAId != 0) ? true : false : false;
        }
    }
}

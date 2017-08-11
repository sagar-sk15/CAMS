using System.ServiceModel;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities;
using Cams.Common.Dto.User;
using Cams.Common.Message;
using AutoMapper;
using Cams.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using Cams.Common.Querying;
using Cams.Common;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class UserGroupService : ServiceBase<UserGroup, UserGroupDto>, IUserGroupService
    {
        #region Constructor
        public UserGroupService()
        {
            AllowSaveWithWarnings = false;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion 

        #region Override the base abstract methods

        protected override void CheckForValidations(UserGroup usergroup)
        {
            usergroup.GetBrokenRules();
            base.IsValid = usergroup.IsValid;
            base.IsValidForBasicMandatoryFields = usergroup.IsValidForBasicMandatoryFields;

            foreach (BusinessRule rule in usergroup.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (!this.IsUniqueName(usergroup, false))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, UserGroupBusinessRules.UserGroupNameUnique.Rule);
                base.IsValid = false;
            }
        }

        protected override void CheckForValidationsWhileUpdating(UserGroup usergroup)
        {
            usergroup.GetBrokenRules();
            base.IsValid = usergroup.IsValid;
            base.IsValidForBasicMandatoryFields = usergroup.IsValidForBasicMandatoryFields;

            foreach (BusinessRule rule in usergroup.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
            if (!this.IsUniqueName(usergroup, true))
            {
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, UserGroupBusinessRules.UserGroupNameUnique.Rule);
                base.IsValid = false;
            }            
        }

        protected override string GetEntityInstanceName(UserGroup entity)
        {
            return entity.UserGroupName;
        }

        public override UserGroupDto EntityToEntityDto(UserGroup entity)
        {
            UserGroupDto usergroupDto = Mapper.Map<UserGroup, UserGroupDto>(entity);
            if(entity != null)
            {
                #region Map UserGroupRolePermission
                usergroupDto.RolePermissionsInUserGroup.Clear();
                if(entity.RolePermissionsInUserGroup != null)
                {
                    foreach (UserGroupRolePermission ugRolePermission in entity.RolePermissionsInUserGroup)
                    {
                        UserGroupRolePermissionDto ugrpDto = new UserGroupRolePermissionDto();
                        ugrpDto = Mapper.Map<UserGroupRolePermission, UserGroupRolePermissionDto>(ugRolePermission);
                        ugrpDto.PermissionForRole = Mapper.Map<Role, RoleDto>(ugRolePermission.PermissionForRole);
                        usergroupDto.RolePermissionsInUserGroup.Add(ugrpDto);
                    }
                }
                if (entity.UsersInUserGroup != null)
                {
                    foreach (User user in entity.UsersInUserGroup)
                    {
                        UserDto userDto = new UserDto();
                        userDto = Mapper.Map<User, UserDto>(user);
                        usergroupDto.UsersInUserGroup.Add(userDto);
                    }
                }
                #endregion 
            }
            return usergroupDto;
        }

        public override UserGroup EntityDtoToEntity(UserGroupDto entityDto)
        {
            UserGroup usergroup = Mapper.Map<UserGroupDto, UserGroup>(entityDto);
            if (entityDto != null)
            {
                #region Map UserGroupRolePermission
                usergroup.RolePermissionsInUserGroup.Clear();
                UserGroupDto ugDB=null; 
                if(entityDto.UserGroupId!=0)
                    ugDB = GetById(entityDto.UserGroupId);
                foreach (UserGroupRolePermissionDto ugrpDto in entityDto.RolePermissionsInUserGroup)
                {
                    UserGroupRolePermission ugRolePermission = new UserGroupRolePermission();
                    ugRolePermission = Mapper.Map<UserGroupRolePermissionDto, UserGroupRolePermission>(ugrpDto);
                    if (ugrpDto.PermissionForRole != null)
                    {
                        if (ugrpDto.PermissionForRole.RoleId != 0)
                        {
                            RoleService roleservice = new RoleService();
                            RoleDto roleDto = roleservice.GetById(ugrpDto.PermissionForRole.RoleId);
                            ugRolePermission.PermissionForRole = Mapper.Map<RoleDto, Role>(roleDto);
                            ugRolePermission.UserGroupRolePermissionId = 0;
                            if (entityDto.UserGroupId != 0)
                            {
                                var ug = ugDB.RolePermissionsInUserGroup.Where(x => x.PermissionForRole.RoleId == roleDto.RoleId);
                                if (ug.Count() != 0)
                                {
                                    ugRolePermission.UserGroupRolePermissionId = ug.First().UserGroupRolePermissionId;
                                    //ugRolePermission.UserGroupRolePermissionId = GetUserGroupRolePermissionIdIfRoleExist(entityDto.UserGroupId, roleDto.RoleId);
                                }
                            }
                        }
                    }
                    usergroup.RolePermissionsInUserGroup.Add(ugRolePermission);
                }
                //if(entityDto.UsersInUserGroup != null)
                //{
                //    foreach (UserDto userDto in entityDto.UsersInUserGroup)
                //    {
                //        User user = new User();
                //        user = Mapper.Map<UserDto, User>(userDto);
                //        usergroup.UsersInUserGroup.Add(user);
                //    }
                //}                
                #endregion 
            }
            return usergroup;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Method to check the usergroup name unique or not
        /// </summary>
        /// <param name="usergroup"></param>
        /// <returns></returns>
        private bool IsUniqueName(UserGroup usergroup, bool IsEdit)
        {
            bool checkresult = false;
            //  UserGroupDto checkresult;
            Query query = new Query();
            Criterion criteriaName = new Criterion(Constants.USERGROUPNAME, usergroup.UserGroupName, CriteriaOperator.Equal);
            Criterion criteriaCAId;
            if(usergroup.CAId!=null)
            {
             criteriaCAId = new Criterion(Constants.CAID, usergroup.CAId, CriteriaOperator.Equal);
            }
            else
            {
                criteriaCAId = new Criterion(Constants.CAID, usergroup.CAId, CriteriaOperator.IsNullOrZero); 
            }
            query.Add(criteriaName);
            query.Add(criteriaCAId);
            if (IsEdit)
            {
                Criterion criteriaUserGroupId = new Criterion("UserGroupId", usergroup.UserGroupId, CriteriaOperator.NotEqual);
                query.Add(criteriaUserGroupId);
            }
            query.QueryOperator = QueryOperator.And;
            var UserGroupList = ExecuteCommand(locator => locator.GetRepository<UserGroup>().FindBy(query));
            if (UserGroupList.Count() == 0)
            {
                checkresult = true;
                // checkresult = new UserGroupDto();
            }
            //else
            //    checkresult = EntityToEntityDto(UserGroupList.FirstOrDefault());
            return checkresult;
        }

        private long GetUserGroupRolePermissionIdIfRoleExist(int userGroupId, int roleId)
        {
            long userRPID = 0;
            UserGroupDto ugDB = GetById(userGroupId);
            //Query query=new Query();
            //Criterion criteriaUGId = new Criterion("UserGroupId", userGroupId, CriteriaOperator.Equal);
            //Criterion criteriaRoleId = new Criterion("role.RoleId", roleId, CriteriaOperator.Equal);
            //query.Add(criteriaUGId);
            //query.Add(criteriaRoleId);
            //query.AddAlias(new Alias("ugRolePermission", "RolePermissionsInUserGroup"));
            //query.AddAlias(new Alias("role", "ugRolePermission.PermissionForRole"));
            //query.QueryOperator = QueryOperator.And;
            //var rolelist = FindByQuery(query);
            //if (rolelist.TotalRecords != 0)
            //    userRPID = rolelist.Entities.ToList().FirstOrDefault().RolePermissionsInUserGroup.FirstOrDefault().UserGroupRolePermissionId;

            return userRPID;
        }

        #endregion
    }
}

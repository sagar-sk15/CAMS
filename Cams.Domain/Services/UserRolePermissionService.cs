using System.ServiceModel;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.Users;
using Cams.Domain.Entities;
using Cams.Common.Dto.User;
using Cams.Common.Message;
using AutoMapper;


namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class UserRolePermissionService : ServiceBase<UserRolePermission, UserRolePermissionDto>, IUserRolePermissionService
    {
        public UserRolePermissionService()
        {
        }

        protected override void CheckForValidations(UserRolePermission userrolepermission)
        {
            userrolepermission.GetBrokenRules();
            base.IsValid = userrolepermission.IsValid;
            base.IsValidForBasicMandatoryFields = userrolepermission.IsValidForBasicMandatoryFields;

            foreach (BusinessRule rule in userrolepermission.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
        }

        protected override void CheckForValidationsWhileUpdating(UserRolePermission entity)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetEntityInstanceName(UserRolePermission entity)
        {
           // return entity.PermissionForUser.Username + " " + entity.PermissionForRole.RoleName;
            return string.Empty;
        }

        public override UserRolePermissionDto EntityToEntityDto(UserRolePermission entity)
        {
            UserRolePermissionDto entityDto = Mapper.Map<UserRolePermission, UserRolePermissionDto>(entity);            
            entityDto.PermissionForRole = Mapper.Map<Role, RoleDto>(entity.PermissionForRole);
           // entityDto.PermissionForUser = Mapper.Map<User, UserDto>(entity.PermissionForUser);
            
            return entityDto;
        }

        public override UserRolePermission EntityDtoToEntity(UserRolePermissionDto entityDto)
        {
            UserRolePermission entity = Mapper.Map<UserRolePermissionDto, UserRolePermission>(entityDto);
            entity.PermissionForRole = Mapper.Map<RoleDto, Role>(entityDto.PermissionForRole);
           // entity.PermissionForUser = Mapper.Map<UserDto, User>(entityDto.PermissionForUser);

            return entity;
        }
    }
}

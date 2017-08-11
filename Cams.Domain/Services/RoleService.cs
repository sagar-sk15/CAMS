using System.ServiceModel;
using Cams.Domain.Entities.Users;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices.WcfRequestContext;
using AutoMapper;

namespace Cams.Domain.Services
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]    
    public class RoleService : ServiceBaseReadOnly<Role, RoleDto>, IRoleService
    {
        public RoleService()
        {
        }

        #region Override the base abstract methods

        public override Role EntityDtoToEntity(RoleDto entityDto)
        {
            Role role = Mapper.Map<RoleDto, Role>(entityDto);
            //if (entityDto != null)
            //{
            //    role.RolesInUserGroupRolePermissions.Clear();
            //    if (entityDto.RolesInUserGroupRolePermissions != null)
            //    {
            //        foreach (UserGroupDto usergroupDto in entityDto.RolesInUserGroupRolePermissions)
            //        {
            //            UserGroup usergroup = new UserGroup();
            //            usergroup = Mapper.Map<UserGroupDto, UserGroup>(usergroupDto);
            //            role.RolesInUserGroupRolePermissions.Add(usergroup);
            //        }
            //    }
            //    role.RolesInUserRolePermissions.Clear();
            //    if(entityDto.RolesInUserRolePermissions != null)
            //    {
            //        foreach(UserRolePermissionDto urpDto in entityDto.RolesInUserRolePermissions) 
            //        {
            //            UserRolePermission URP = new UserRolePermission();
            //            URP = Mapper.Map<UserRolePermissionDto, UserRolePermission>(urpDto);
            //            role.RolesInUserRolePermissions.Add(URP);
            //        }
            //    }
            //}
            return role;
        }

        public override RoleDto EntityToEntityDto(Role entity)
        {
            RoleDto roledto = Mapper.Map<Role, RoleDto>(entity);
            if(entity != null)
            {
            //    roledto.RolesInUserGroupRolePermissions.Clear();
            //    if (entity.RolesInUserGroupRolePermissions != null)
            //    {
            //        foreach (UserGroup usergroup in entity.RolesInUserGroupRolePermissions)
            //        {
            //            UserGroupDto usergroupDto = new UserGroupDto();
            //            usergroupDto = Mapper.Map<UserGroup, UserGroupDto>(usergroup);
            //            roledto.RolesInUserGroupRolePermissions.Add(usergroupDto);
            //        }
            //    }
            //    roledto.RolesInUserRolePermissions.Clear();
            if (entity.RolesInUserRolePermissions != null)
            {
                foreach (UserRolePermission URP in entity.RolesInUserRolePermissions)
                {
                    UserRolePermissionDto urpDto = new UserRolePermissionDto();
                    urpDto = Mapper.Map<UserRolePermission, UserRolePermissionDto>(URP);
                    roledto.RolesInUserRolePermissions.Add(urpDto);
                }
            }
            }
            return roledto;
        }
        #endregion  
    }
}

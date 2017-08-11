using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services.Wcf
{
    public class UserRolePermissionServiceProxy : WcfAdapterBase<IUserRolePermissionService>, IUserRolePermissionService
    {
        #region Implementation of IUserRolePermissionService

        public UserRolePermissionDto GetById(long id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<UserRolePermissionDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public UserRolePermissionDto Update(UserRolePermissionDto user, UserDto loggedInUserDto)
        {
            return ExecuteCommand(proxy => proxy.Update(user,loggedInUserDto));
        }

        public UserRolePermissionDto Create(UserRolePermissionDto user, UserDto loggedInUserDto)
        {
            return ExecuteCommand(proxy => proxy.Create(user,loggedInUserDto));
        }
        #endregion

        
    }
}

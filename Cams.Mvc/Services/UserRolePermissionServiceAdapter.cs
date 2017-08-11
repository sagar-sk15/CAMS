using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services
{
    public class UserRolePermissionServiceAdapter
        : ServiceAdapterBase<IUserRolePermissionService>, IUserRolePermissionService
    {
        public UserRolePermissionServiceAdapter(IUserRolePermissionService service)
            : base(service) { }

        #region Implementation of IUserRolePermissionService

        public UserRolePermissionDto GetById(long id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public UserRolePermissionDto Update(UserRolePermissionDto user, UserDto loggedInUserDto)
        {
            return ExecuteCommand(() => Service.Update(user,loggedInUserDto));
        }

        public UserRolePermissionDto Create(UserRolePermissionDto user, UserDto loggedInUserDto)
        {
            return ExecuteCommand(() => Service.Create(user,loggedInUserDto));
        }

        public Cams.Common.Dto.EntityDtos<UserRolePermissionDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

       
        #endregion
    }
}

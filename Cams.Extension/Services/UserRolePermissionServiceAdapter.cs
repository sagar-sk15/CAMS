using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
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

        public UserRolePermissionDto Update(UserRolePermissionDto userRolePermissionDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(userRolePermissionDto, userName));
        }

        public UserRolePermissionDto Create(UserRolePermissionDto userRolePermissionDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(userRolePermissionDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<UserRolePermissionDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

       
        #endregion
    }
}

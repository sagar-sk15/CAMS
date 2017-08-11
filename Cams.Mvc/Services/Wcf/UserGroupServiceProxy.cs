using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services.Wcf
{
    public class UserGroupServiceProxy : WcfAdapterBase<IUserGroupService>, IUserGroupService
    {

        #region Implementation of IUserGroupService

        public UserGroupDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public UserGroupDto Update(UserGroupDto usergroup, UserDto userDto)
        {
            return ExecuteCommand(proxy => proxy.Update(usergroup, userDto));
        }

        public UserGroupDto Create(UserGroupDto usergroup, UserDto userDto)
        {
            return ExecuteCommand(proxy => proxy.Create(usergroup, userDto));
        }
               

        #endregion

    }
}

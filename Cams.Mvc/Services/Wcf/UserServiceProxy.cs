using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services.Wcf
{
    public class UserServiceProxy : WcfAdapterBase<IUserService>, IUserService
    {
        #region Implementation of IUserService

        public UserDto GetById(long id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public UserDto Update(UserDto user,UserDto loggedInUserDto)
        {
            return ExecuteCommand(proxy => proxy.Update(user,loggedInUserDto));
        }

        public UserDto Create(UserDto user, UserDto loggedInUserDto)
        {
            return ExecuteCommand(proxy => proxy.Create(user,loggedInUserDto));
        }
        #endregion


        public UserDto GetByUsername(string Username, string Password)
        {
            return ExecuteCommand(proxy => proxy.GetByUsername(Username, Password));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services
{
    public class UserServiceAdapter
        : ServiceAdapterBase<IUserService>, IUserService
    {
        public UserServiceAdapter(IUserService service)
            : base(service) { }

        #region Implementation of IUserService

        public UserDto GetById(long id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public UserDto Update(UserDto user, UserDto loggedInUserDto)
        {
            return ExecuteCommand(() => Service.Update(user,loggedInUserDto));
        }

        public UserDto Create(UserDto user,UserDto loggedInUserDto)
        {
            return ExecuteCommand(() => Service.Create(user,loggedInUserDto));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public UserDto GetByUsername(string Username, string Password)
        {
            return ExecuteCommand(() => Service.GetByUsername(Username, Password));
        }
        #endregion
    }
}

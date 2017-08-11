using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Mvc.Services
{
    public class UserGroupServiceAdapter : ServiceAdapterBase<IUserGroupService>, IUserGroupService
    {
        public UserGroupServiceAdapter(IUserGroupService service) 
            : base(service) { }
        #region Implementation of IUserGroupService

        public UserGroupDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public UserGroupDto Update(UserGroupDto usergroup,UserDto userDto)
        {
            return ExecuteCommand(() => Service.Update(usergroup, userDto));
        }

        public UserGroupDto Create(UserGroupDto usergroup, UserDto userDto)
        {
            return ExecuteCommand(() => Service.Create(usergroup, userDto));
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }
                
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
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

        public UserDto Update(UserDto user,string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(user,userName));
        }

        public UserDto Create(UserDto user, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(user,userName));
        }
        #endregion


        public UserDto Login(string Username, string Password)
        {
            return ExecuteCommand(proxy => proxy.Login(Username, Password));
        }

        public UserDto GetByUserName(string Username)
        {
            return ExecuteCommand(proxy => proxy.GetByUserName(Username));
        }

        public List<string> GetAvailableUsernameList(string FullName, string Username)
        {
            return GetAvailableUsernameList(FullName, Username);
        }


        public UserDto GetByUsername(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindBy(Cams.Common.Querying.Query query, int pageIndex, int recordsPerPage, bool populateChildObjects)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage,populateChildObjects));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindByQuery(Cams.Common.Querying.Query query, bool populateChildObjects)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query,populateChildObjects));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> GetAccountManagerList()
        {
            return ExecuteCommand(proxy => proxy.GetAccountManagerList());
        }
    }
}

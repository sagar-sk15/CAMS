using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
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

        public UserDto Update(UserDto user, string userName)
        {
            return ExecuteCommand(() => Service.Update(user,userName));
        }

        public UserDto Create(UserDto user, string userName)
        {
            return ExecuteCommand(() => Service.Create(user,userName));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public UserDto Login(string Username, string Password)
        {
            return ExecuteCommand(() => Service.Login(Username, Password));
        }

        public UserDto GetByUserName(string Username)
        {
            return ExecuteCommand(() => Service.GetByUserName(Username));
        }

        public List<string> GetAvailableUsernameList(string FullName, string Username)
        {
            return GetAvailableUsernameList(FullName, Username);
        }

        public UserDto GetByUsername(string Username, string Password)
        {
            throw new NotImplementedException();
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindBy(Query query, int pageIndex, int recordsPerPage, bool populateChildObjects)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage,populateChildObjects));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> FindByQuery(Query query, bool populateChildObjects)
        {
            return ExecuteCommand(() => Service.FindByQuery(query,populateChildObjects));
        }

        public Cams.Common.Dto.EntityDtos<UserDto> GetAccountManagerList()
        {
            return ExecuteCommand(() => Service.GetAccountManagerList()); 
        }
        #endregion
    }
}

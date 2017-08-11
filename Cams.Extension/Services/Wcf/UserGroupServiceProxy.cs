using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services.Wcf
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

        public UserGroupDto Update(UserGroupDto usergroup, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(usergroup, userName));
        }

        public UserGroupDto Create(UserGroupDto usergroup, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(usergroup, userName));
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query,pageIndex,recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
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

        public UserGroupDto Update(UserGroupDto userGroupDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(userGroupDto, userName));
        }

        public UserGroupDto Create(UserGroupDto userGroupDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(userGroupDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<UserGroupDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
        #endregion
    }
}
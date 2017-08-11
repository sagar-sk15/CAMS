using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class RoleServiceProxy : WcfAdapterBase<IRoleService>, IRoleService
    {
        #region Implementation of IRoleService

        public RoleDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<RoleDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public Common.Dto.EntityDtos<RoleDto> FindByQuery(Common.Querying.Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
{
    public class RoleServiceAdapter : ServiceAdapterBase<IRoleService>, IRoleService
    {
        public RoleServiceAdapter(IRoleService service)
            : base(service) { }

        #region Implementation of IRoleService

        public RoleDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<RoleDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public Common.Dto.EntityDtos<RoleDto> FindByQuery(Common.Querying.Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
        #endregion      
    }
}
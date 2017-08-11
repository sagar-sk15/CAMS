using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.Masters;

namespace Cams.Extension.Services.Wcf
{
    public class APMCServiceProxy : WcfAdapterBase<IAPMCService>, IAPMCService
    {
        public APMCDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<APMCDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<APMCDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public APMCDto Update(APMCDto ApmcDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(ApmcDto, userName));
        }

        public APMCDto Create(APMCDto ApmcDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(ApmcDto, userName));
        }
    }
}

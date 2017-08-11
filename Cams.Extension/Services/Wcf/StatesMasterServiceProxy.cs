using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class StatesMasterServiceProxy : WcfAdapterBase<IStateService>,IStateService
    {
     public StateDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<StateDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<StateDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, 0, 0));
        }

        public StateDto Update(StateDto statesMasterDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(statesMasterDto,userName));
        }

        public StateDto Create(StateDto statesMasterDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(statesMasterDto,userName));
        }
      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class LabourChargeTypeServiceProxy : WcfAdapterBase<ILabourChargeTypeService>, ILabourChargeTypeService
    {
        public LabourChargeTypeDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<LabourChargeTypeDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<LabourChargeTypeDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, 0, 0));
        }

        public LabourChargeTypeDto Update(LabourChargeTypeDto labourchargetypeDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(labourchargetypeDto, userName));
        }

        public LabourChargeTypeDto Create(LabourChargeTypeDto labourchargetypeDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(labourchargetypeDto, userName));
        }

        public Cams.Common.Dto.EntityDtos<LabourChargeTypeDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
    }
}

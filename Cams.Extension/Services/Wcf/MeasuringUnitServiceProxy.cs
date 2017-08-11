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
    public class MeasuringUnitServiceProxy : WcfAdapterBase<IMeasuringUnitService>, IMeasuringUnitService
    {
        public MeasuringUnitDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<MeasuringUnitDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<MeasuringUnitDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, 0, 0));
        }

        public MeasuringUnitDto Update(MeasuringUnitDto measuringunitdto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(measuringunitdto, userName));
        }

        public MeasuringUnitDto Create(MeasuringUnitDto measuringunitdto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(measuringunitdto, userName));
        }

        public Cams.Common.Dto.EntityDtos<MeasuringUnitDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
    }
}

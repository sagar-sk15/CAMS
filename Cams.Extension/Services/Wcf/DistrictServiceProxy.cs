using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class DistrictServiceProxy : WcfAdapterBase<IDistrictService>,IDistrictService
    {
        public DistrictDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<DistrictDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<DistrictDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public EntityDtos<DistrictDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }

        public DistrictDto Update(DistrictDto districtDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(districtDto, userName));
        }

        public DistrictDto Create(DistrictDto districtDto, string userName) 
        {
            return ExecuteCommand(proxy => proxy.Create(districtDto, userName));
        }
    }
}

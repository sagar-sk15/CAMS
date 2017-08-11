using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://cams/zoneservice/")]
    public interface IZoneService:IContract
    {
        [OperationContract]
        ZoneDto GetById(long id);

        [OperationContract]
        ZoneDto Update(ZoneDto zonetDto, string userName);

        [OperationContract]
        ZoneDto Create(ZoneDto zonetDto, string userName);

        [OperationContract]
        EntityDtos<ZoneDto> FindAll();

        [OperationContract]
        EntityDtos<ZoneDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<ZoneDto> FindByQuery(Query query);
    }
}

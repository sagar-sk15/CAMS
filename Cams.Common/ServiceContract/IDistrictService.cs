using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://cams/districtservice/")]
    public interface IDistrictService : IContract
    {
        [OperationContract]
        DistrictDto GetById(int id);

        [OperationContract]
        DistrictDto Update(DistrictDto districtDto, string userName);

        [OperationContract]
        DistrictDto Create(DistrictDto districtDto, string userName);

        [OperationContract]
        EntityDtos<DistrictDto> FindAll();

        [OperationContract]
        EntityDtos<DistrictDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<DistrictDto> FindByQuery(Query query);

    }
}

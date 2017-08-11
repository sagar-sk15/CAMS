using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://cams/MeasuringUnitService/")]
    public interface IMeasuringUnitService : IContract
    {
        [OperationContract]
        MeasuringUnitDto GetById(int id);

        [OperationContract]
        MeasuringUnitDto Update(MeasuringUnitDto labourchargetypeDto, string userName);

        [OperationContract]
        MeasuringUnitDto Create(MeasuringUnitDto labourchargetypeDto, string userName);

        [OperationContract]
        EntityDtos<MeasuringUnitDto> FindAll();

        [OperationContract]
        EntityDtos<MeasuringUnitDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<MeasuringUnitDto> FindByQuery(Query query);
    }
}

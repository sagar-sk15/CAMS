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
    [ServiceContract(Namespace = "http://cams/LabourChargeTypeService/")]
    public interface ILabourChargeTypeService : IContract
    {
        [OperationContract]
        LabourChargeTypeDto GetById(int id);

        [OperationContract]
        LabourChargeTypeDto Update(LabourChargeTypeDto labourchargetypeDto, string userName);

        [OperationContract]
        LabourChargeTypeDto Create(LabourChargeTypeDto labourchargetypeDto, string userName);

        [OperationContract]
        EntityDtos<LabourChargeTypeDto> FindAll();

        [OperationContract]
        EntityDtos<LabourChargeTypeDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<LabourChargeTypeDto> FindByQuery(Query query);
    }
}

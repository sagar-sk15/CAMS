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
     [ServiceContract(Namespace = "http://Cams/apmcservices/")]
    public interface IAPMCService:IContract
    {
        [OperationContract]
        APMCDto GetById(int id);

        [OperationContract]
        APMCDto Update(APMCDto apmcDto, string userName);

        [OperationContract]
        APMCDto Create(APMCDto apmcDto, string userName);

        [OperationContract]
        EntityDtos<APMCDto> FindAll();

        [OperationContract]
        EntityDtos<APMCDto> FindBy(Query query, int pageIndex, int recordsPerPage);

    }
}

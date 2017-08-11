using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://cams/commodityclassservices/")]
    public interface ICommodityClassService:IContract
    {
        [OperationContract]
        CommodityClassDto GetById(int id);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<CommodityClassDto> FindAll();

        [OperationContract]
        EntityDtos<CommodityClassDto> FindByQuery(Query query);
    }
}

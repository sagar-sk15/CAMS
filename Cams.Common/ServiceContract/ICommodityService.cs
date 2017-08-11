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
    [ServiceContract(Namespace = "http://Cams/commodityservices/")]
    public interface ICommodityService:IContract
    {
        [OperationContract]
        CommodityDto GetById(int id);

        [OperationContract]
        CommodityDto Update(CommodityDto commodityDto, string userName);

        [OperationContract]
        CommodityDto Create(CommodityDto commodityDto, string userName);

        [OperationContract]
        EntityDtos<CommodityDto> FindAll();

        [OperationContract]
        EntityDtos<CommodityDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<CommodityDto> FindByQuery(Query query);
    }
}

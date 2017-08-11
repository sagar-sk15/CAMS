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
    [ServiceContract(Namespace = "http://cams/cityvillageservice/")]
    public interface ICityVillageService : IContract
    { 
        [OperationContract]
        CityVillageDto GetById(int id);

        [OperationContract]
        CityVillageDto Update(CityVillageDto cityvillagetDto, string userName);

        [OperationContract]
        CityVillageDto Create(CityVillageDto cityvillagetDto, string userName);

        [OperationContract]
        EntityDtos<CityVillageDto> FindAll();

        [OperationContract]
        EntityDtos<CityVillageDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        EntityDtos<CityVillageDto> FindByQuery(Query query);
    }
}

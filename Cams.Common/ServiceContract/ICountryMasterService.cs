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
    [ServiceContract(Namespace = "https://countrymasterservice/")]
    public interface ICountryMasterService :IContract
    {
        [OperationContract]
        CountryDto GetById(int id);

        [OperationContract]
        CountryDto Update(CountryDto countryDto, string userName);

        [OperationContract]
        CountryDto Create(CountryDto countryDto, string userName);

        [OperationContract]
        EntityDtos<CountryDto> FindAll();

        [OperationContract]
        EntityDtos<CountryDto> FindBy(Query query, int pageIndex, int recordsPerPage);

        [OperationContract]
        CountryDto GetByCountryName(string countryName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Querying;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    /// Exposes the BusinessConstitution services
    /// </summary>
    [ServiceContract(Namespace = "http://cams/businessconstitutionservices/")]
    public interface IBusinessConstitutionService:IContract
    {
        [OperationContract]
        BusinessConstitutionDto GetById(int id);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<BusinessConstitutionDto> FindAll();

        [OperationContract]
        Cams.Common.Dto.EntityDtos<BusinessConstitutionDto> FindByQuery(Query query);
    }
}

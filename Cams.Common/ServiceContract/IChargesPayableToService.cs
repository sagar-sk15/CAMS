using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Common.ServiceContract
{
    [ServiceContract(Namespace = "http://cams/ChargesPayableToServices/")]
    public interface IChargesPayableToService : IContract
    {
        [OperationContract]
        ChargesPayableToDto GetById(int id);

        [OperationContract]
        Cams.Common.Dto.EntityDtos<ChargesPayableToDto> FindAll();
    }
}

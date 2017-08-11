using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.User;

namespace Cams.Common.ServiceContract
{
    /// <summary>
    ///  Exposes the Address services
    /// </summary>
    [ServiceContract(Namespace = "http://Cams/addressservices/")]
    public interface IAddressService
        :IContract
    {
        [OperationContract]
        AddressDto GetById(long id);

        [OperationContract]
        AddressDto Update(AddressDto address, string userName);

        [OperationContract]
        AddressDto Create(AddressDto address, string userName);
    }
}

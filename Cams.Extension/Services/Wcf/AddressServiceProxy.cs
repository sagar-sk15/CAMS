using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Address;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.User;

namespace Cams.Extension.Services.Wcf
{
    public class AddressServiceProxy : WcfAdapterBase<IAddressService>, IAddressService
    {
        #region Implementation of IAddressService

        public AddressDto GetById(long id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public AddressDto Update(AddressDto address, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(address, userName));
        }

        public AddressDto Create(AddressDto address, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(address, userName));
        }

        #endregion
    }
}

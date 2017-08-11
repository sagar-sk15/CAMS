using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Address;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.User;

namespace Cams.Mvc.Services.Wcf
{
    public class AddressServiceProxy : WcfAdapterBase<IAddressService>, IAddressService
    {
        #region Implementation of IAddressService

        public AddressDto GetById(long id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public AddressDto Update(AddressDto address,UserDto userDto)
        {
            return ExecuteCommand(proxy => proxy.Update(address, userDto));
        }

        public AddressDto Create(AddressDto address, UserDto userDto)
        {
            return ExecuteCommand(proxy => proxy.Create(address, userDto));
        }

        #endregion
    }
}

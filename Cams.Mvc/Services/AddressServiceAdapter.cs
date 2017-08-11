using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Address;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.User;

namespace Cams.Mvc.Services
{
    public class AddressServiceAdapter
        : ServiceAdapterBase<IAddressService>, IAddressService
    {
        public AddressServiceAdapter(IAddressService service) 
            : base(service) { }

        #region Implementation of IAddressService

        public AddressDto GetById(long id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public AddressDto Update(AddressDto address,UserDto userDto)
        {
            return ExecuteCommand(() => Service.Update(address, userDto));
        }

        public AddressDto Create(AddressDto address, UserDto userDto)
        {
            return ExecuteCommand(() => Service.Create(address, userDto));
        }

        #endregion
    }
}

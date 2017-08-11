using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Address;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.User;

namespace Cams.Extension.Services
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

        public AddressDto Update(AddressDto address, string userName)
        {
            return ExecuteCommand(() => Service.Update(address, userName));
        }

        public AddressDto Create(AddressDto address, string userName)
        {
            return ExecuteCommand(() => Service.Create(address, userName));
        }

        #endregion
    }
}

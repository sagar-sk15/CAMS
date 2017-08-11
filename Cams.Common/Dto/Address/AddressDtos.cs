using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Address
{
    public class AddressDtos : DtoBase
    {
        public IList<AddressDto> Addresses { get; set; }
    }

}

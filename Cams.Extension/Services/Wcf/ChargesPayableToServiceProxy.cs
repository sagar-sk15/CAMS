using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class ChargesPayableToServiceProxy : WcfAdapterBase<IChargesPayableToService>, IChargesPayableToService
    {
        #region Implementation of IChargesPayableToService

        public ChargesPayableToDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<ChargesPayableToDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }
        #endregion
    }
}

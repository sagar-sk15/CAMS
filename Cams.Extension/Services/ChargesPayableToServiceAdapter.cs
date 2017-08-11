using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
{
    public class ChargesPayableToServiceAdapter : ServiceAdapterBase<IChargesPayableToService>, IChargesPayableToService
    {
        public ChargesPayableToServiceAdapter(IChargesPayableToService service)
            : base(service) { }

        #region Implementation of ChargesPayableToServiceAdapter

        public ChargesPayableToDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<ChargesPayableToDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class BusinessConstitutionServiceProxy : WcfAdapterBase<IBusinessConstitutionService>, IBusinessConstitutionService
    {
        #region Implementation of IBusinessConstitutionService

        public BusinessConstitutionDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<BusinessConstitutionDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public Common.Dto.EntityDtos<BusinessConstitutionDto> FindByQuery(Common.Querying.Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }
        #endregion
    }
}

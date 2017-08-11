using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
{
    public class BusinessConstitutionServiceAdapter : ServiceAdapterBase<IBusinessConstitutionService>, IBusinessConstitutionService 
    {
        public BusinessConstitutionServiceAdapter(IBusinessConstitutionService service)
            : base(service) { }

        #region Implementation of IBusinessConstitutionService

        public BusinessConstitutionDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<BusinessConstitutionDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public Common.Dto.EntityDtos<BusinessConstitutionDto> FindByQuery(Common.Querying.Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
        #endregion
    }
}

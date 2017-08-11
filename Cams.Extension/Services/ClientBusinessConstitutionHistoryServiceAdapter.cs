using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;
using Cams.Common.Dto;

namespace Cams.Extension.Services
{
    public class ClientBusinessConstitutionHistoryServiceAdapter : ServiceAdapterBase<IClientBusinessConstitutionHistoryService>, IClientBusinessConstitutionHistoryService  
    {
        public ClientBusinessConstitutionHistoryServiceAdapter(IClientBusinessConstitutionHistoryService service)
            : base(service) { }

        #region Implementation of IBusinessConstitutionService

        public EntityDtos<ClientBusinessConstitutionHistoryDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<ClientBusinessConstitutionHistoryDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }

        #endregion 
    }
}

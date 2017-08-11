using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.Masters;

namespace Cams.Extension.Services
{
    public class APMCServiceAdapter : ServiceAdapterBase<IAPMCService>, IAPMCService
    {
        public APMCServiceAdapter(IAPMCService service)
            : base(service) { }

        public APMCDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public APMCDto Update(APMCDto ApmcDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(ApmcDto, userName));
        }

        public APMCDto Create(APMCDto ApmcDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(ApmcDto, userName));
        }

        public Common.Dto.EntityDtos<APMCDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<APMCDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

    }
}

using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.Masters;

namespace Cams.Extension.Services
{
    public class StatesMasterServiceAdapter : ServiceAdapterBase<IStateService>,IStateService
    {
        public StatesMasterServiceAdapter(IStateService service)
            : base(service) { }
     
        public StateDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public StateDto Update(StateDto statesMasterDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(statesMasterDto, userName));
        }

        public StateDto Create(StateDto statesMasterDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(statesMasterDto, userName));
        }

        public Common.Dto.EntityDtos<StateDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<StateDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, 0, 0));
        }
    }
}
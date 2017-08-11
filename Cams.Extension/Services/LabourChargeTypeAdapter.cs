using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class LabourChargeTypeAdapter : ServiceAdapterBase<ILabourChargeTypeService>, ILabourChargeTypeService
    {
        public LabourChargeTypeAdapter(ILabourChargeTypeService service)
            : base(service) { }

        public LabourChargeTypeDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public LabourChargeTypeDto Update(LabourChargeTypeDto labourchargetypedto, string userName)
        {
            return ExecuteCommand(() => Service.Update(labourchargetypedto, userName));
        }

        public LabourChargeTypeDto Create(LabourChargeTypeDto labourchargetypedto, string userName)
        {
            return ExecuteCommand(() => Service.Create(labourchargetypedto, userName));
        }

        public Common.Dto.EntityDtos<LabourChargeTypeDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<LabourChargeTypeDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, 0, 0));
        }

        public Cams.Common.Dto.EntityDtos<LabourChargeTypeDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

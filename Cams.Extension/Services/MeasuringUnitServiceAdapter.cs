using Cams.Common.Dto;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class MeasuringUnitServiceAdapter : ServiceAdapterBase<IMeasuringUnitService>, IMeasuringUnitService
    {
        public MeasuringUnitServiceAdapter(IMeasuringUnitService service)
            : base(service) { }

        public MeasuringUnitDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public MeasuringUnitDto Update(MeasuringUnitDto measuringunitdto, string userName)
        {
            return ExecuteCommand(() => Service.Update(measuringunitdto, userName));
        }

        public MeasuringUnitDto Create(MeasuringUnitDto measuringunitdto, string userName)
        {
            return ExecuteCommand(() => Service.Create(measuringunitdto, userName));
        }

        public Common.Dto.EntityDtos<MeasuringUnitDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<MeasuringUnitDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, 0, 0));
        }

        public Cams.Common.Dto.EntityDtos<MeasuringUnitDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

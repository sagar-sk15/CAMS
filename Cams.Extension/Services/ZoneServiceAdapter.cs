using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class ZoneServiceAdapter : ServiceAdapterBase<IZoneService>, IZoneService
    {
        public ZoneServiceAdapter(IZoneService service)
            : base(service) { }

        public ZoneDto GetById(long id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public ZoneDto Update(ZoneDto zoneDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(zoneDto, userName));
        }

        public ZoneDto Create(ZoneDto zoneDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(zoneDto, userName));
        }

        public Common.Dto.EntityDtos<ZoneDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<ZoneDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, 0, 0));
        }

        public Cams.Common.Dto.EntityDtos<ZoneDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

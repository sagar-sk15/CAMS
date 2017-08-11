using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class DistrictServiceAdapter : ServiceAdapterBase<IDistrictService>,IDistrictService
    {
        public DistrictServiceAdapter(IDistrictService service)
            : base(service) { }

        public DistrictDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public DistrictDto Update(DistrictDto districtDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(districtDto, userName));
        }

        public DistrictDto Create(DistrictDto districtDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(districtDto, userName));
        }

        public Common.Dto.EntityDtos<DistrictDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<DistrictDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public EntityDtos<DistrictDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

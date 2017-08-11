using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class CityVillageServiceAdapter : ServiceAdapterBase<ICityVillageService>, ICityVillageService
    {
        public CityVillageServiceAdapter(ICityVillageService service)
            : base(service) { }

        public CityVillageDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public CityVillageDto Update(CityVillageDto cityvillageDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(cityvillageDto, userName));
        }

        public CityVillageDto Create(CityVillageDto cityvillageDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(cityvillageDto, userName));
        }

        public Common.Dto.EntityDtos<CityVillageDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<CityVillageDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public EntityDtos<CityVillageDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

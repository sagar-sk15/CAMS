using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Extension.Services
{
    public class CommodityServiceAdapter : ServiceAdapterBase<ICommodityService>, ICommodityService
    {
        public CommodityServiceAdapter(ICommodityService service)
            : base(service) { }
     
        public CommodityDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public CommodityDto Update(CommodityDto commodityDto, string userName)
        {
            return ExecuteCommand(() => Service.Update(commodityDto, userName));
        }

        public CommodityDto Create(CommodityDto commodityDto, string userName)
        {
            return ExecuteCommand(() => Service.Create(commodityDto, userName));
        }

        public Common.Dto.EntityDtos<CommodityDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public EntityDtos<CommodityDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, pageIndex, recordsPerPage));
        }

        public Cams.Common.Dto.EntityDtos<CommodityDto> FindByQuery(Query query)
        {
            return ExecuteCommand(() => Service.FindByQuery(query));
        }
    }
}

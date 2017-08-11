using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class CityVillageServiceProxy : WcfAdapterBase<ICityVillageService>, ICityVillageService
    {
        public CityVillageDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<CityVillageDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<CityVillageDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, pageIndex, recordsPerPage));
        }

        public EntityDtos<CityVillageDto> FindByQuery(Query query)
        {
            return ExecuteCommand(proxy => proxy.FindByQuery(query));
        }

        public CityVillageDto Update(CityVillageDto cityvillageDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(cityvillageDto, userName));
        }

        public CityVillageDto Create(CityVillageDto cityvillageDto, string userName) 
        {
            return ExecuteCommand(proxy => proxy.Create(cityvillageDto, userName));
        }
    }
}

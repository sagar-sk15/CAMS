using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services.Wcf
{
    public class CountryMasterServiceProxy : WcfAdapterBase<ICountryMasterService>,ICountryMasterService
    {
     public CountryDto GetById(int id)
        {
            return ExecuteCommand(proxy => proxy.GetById(id));
        }

        public EntityDtos<CountryDto> FindAll()
        {
            return ExecuteCommand(proxy => proxy.FindAll());
        }

        public EntityDtos<CountryDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(proxy => proxy.FindBy(query, 0, 0));
        }

        public CountryDto Update(CountryDto CountryMasterDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Update(CountryMasterDto,userName));
        }

        public CountryDto Create(CountryDto CountryMasterDto, string userName)
        {
            return ExecuteCommand(proxy => proxy.Create(CountryMasterDto,userName));
        }

        public CountryDto GetByCountryName(string countryname)
        {
            return ExecuteCommand(proxy => proxy.GetByCountryName(countryname));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto;
using Cams.Common.Dto.User;
using Cams.Common.ServiceContract;
using Cams.Common.Querying;

namespace Cams.Extension.Services
{
    public class CountryMasterServiceAdapter : ServiceAdapterBase<ICountryMasterService>, ICountryMasterService
    {
        public CountryMasterServiceAdapter(ICountryMasterService service)
            : base(service) { }

        #region Implementation of ICountryService

        public CountryDto GetById(int id)
        {
            return ExecuteCommand(() => Service.GetById(id));
        }

        public Cams.Common.Dto.EntityDtos<CountryDto> FindAll()
        {
            return ExecuteCommand(() => Service.FindAll());
        }

        public CountryDto Update(CountryDto country, string userName)
        {
            return ExecuteCommand(() => Service.Update(country, userName));
        }

        public CountryDto Create(CountryDto country, string userName)
        {
            return ExecuteCommand(() => Service.Create(country, userName));
        }

        public CountryDto GetByCountryName(string countryname)
        {
            return ExecuteCommand(() => Service.GetByCountryName(countryname));
        }

        public EntityDtos<CountryDto> FindBy(Query query, int pageIndex, int recordsPerPage)
        {
            return ExecuteCommand(() => Service.FindBy(query, 0, 0));
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.Address;

namespace Cams.Common.Dto.Masters
{
    public class CityVillageDto : DtoBase
    {
        public CityVillageDto()
        {
            Addresses = new List<AddressDto>();
        }

        public virtual int CityVillageId { get; set; }
        public virtual string Name { get; set; }
        public virtual Common.CityVillageType CityOrVillage { get; set; }
        public virtual string STDCode { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual Nullable<int> BaseCityVillageId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        public virtual DistrictDto DistrictOfCityVillage { get; set; }
        public virtual IList<AddressDto> Addresses { get; set; }
    }
}

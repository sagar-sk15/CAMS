using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using  Cams.Common.Dto.Masters;

namespace Cams.Common.Dto.Masters
{
    public class DistrictDto : DtoBase
    {
        public DistrictDto() 
        {
            CitiesOrVillages = new List<CityVillageDto>();
        }

        public virtual int DistrictId { get; set; }
        public virtual string DistrictName { get; set; }
        public virtual StateDto StateOfDistrict { get; set; }
        public virtual IList<CityVillageDto> CitiesOrVillages { get; set; }
    }
}

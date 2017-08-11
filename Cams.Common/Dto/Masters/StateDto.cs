using Cams.Common.Message;
using System.Collections.Generic;

namespace Cams.Common.Dto.Masters
{
    public class StateDto : DtoBase
    {
        public StateDto() 
        {
            DistrictsInState = new List<DistrictDto>();
        }
        public virtual int StateId { get; set; }
        public virtual string RegionType { get; set; }
        public virtual string RegionName { get; set; }
        public virtual CountryDto StateInCountry { get; set; }
        public virtual IList<DistrictDto> DistrictsInState { get; set; }
    }
}

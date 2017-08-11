using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.Masters;
using Cams.Web.MVCRazor.Models.Shared;

namespace Cams.Web.MVCRazor.Models.Masters
{
    public class APMCModel : APMCDto
    {
        public APMCModel()
        {
            Address = new AddressDto();
            ContactNos = new List<ContactDetailsDto>();
            ContactNos.Add(
                              new ContactDetailsDto()
                                  {
                                      ContactNoType = Common.ContactType.MobileNo,
                                      ContactNo = "",
                                      STDCode = "020",
                                      CountryCallingCode = "+91"
                                  }
                          );

            APMCList = new List<APMCDto>();
            StateDistrictPlacesControlNames = new List<StateDistrictCityControlNamesModel>();
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel(""));
            StateDistrictPlacesControlNames.Add(new Shared.StateDistrictCityControlNamesModel("CA"));
        }
        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "APMCValidateNAME")]
        public override string Name { get; set; }
        public override string Status { get; set; }
        public IList<ContactDetailsDto> Contacts { get; set; }
        public override string Website { get; set; }
        public override string Email1 { get; set; }
        public override string Email2 { get; set; }
        public List<APMCDto> APMCList;
        public IList<Cams.Web.MVCRazor.Models.Shared.StateDistrictCityControlNamesModel> StateDistrictPlacesControlNames;
    }
}
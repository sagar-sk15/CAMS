using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.Masters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cams.Web.MVCRazor.Models.ClientMasters
{
    public class ZoneModel : ZoneDto
    {
        public ZoneModel()
        {
            ZoneList = new List<ZoneDto>();
            ZoneFor = Common.ZoneFor.Customer;
            IsActive = true;
        }
        public IList<ZoneDto> ZoneList;

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "ZoneRequiredZoneFor")]
        public override Common.ZoneFor ZoneFor { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "ZoneRequiredZone")]
        [RegularExpression(@"[0-9a-zA-Z\s]{1,60}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "ZoneRegXZone")]
        public override string Name { get; set; }
    }
}
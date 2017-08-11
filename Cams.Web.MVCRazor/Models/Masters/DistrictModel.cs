using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Cams.Common.Dto.Masters;

namespace Cams.Web.MVCRazor.Models.Masters
{
    public class DistrictModel : DistrictDto
    {
        [DefaultValue("India")]
        public string Country { get; set; }
        public override string DistrictName { get; set; }
    }
}
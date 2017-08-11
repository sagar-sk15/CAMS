using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Cams.Common.Dto.Masters;

namespace Cams.Web.MVCRazor.Models.Masters
{    
    public class AddStateModel
    {
        public AddStateModel()
        {
        }
        [DefaultValue("India")]
        public string Country { get; set; }        
        public string RegionType { get; set; }
        [Required(ErrorMessageResourceType = typeof(ClientResources), ErrorMessageResourceName = "AstValidateRegionName")]
        public string RegionName { get; set; }
    }
}
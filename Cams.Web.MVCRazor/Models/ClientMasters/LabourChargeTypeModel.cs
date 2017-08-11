using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientMasters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cams.Web.MVCRazor.Models.ClientMasters
{
    public class LabourChargeTypeModel : LabourChargeTypeDto
    {
        public LabourChargeTypeModel()
        {
            ChargesPayableToList = new List<ChargesPayableToDto>();
            LabourChargeTypeList = new List<LabourChargeTypeDto>();
        }
        public List<ChargesPayableToDto> ChargesPayableToList;
        public List<LabourChargeTypeDto> LabourChargeTypeList;
        public bool IsDerivative { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "LCTRequiredLabourCharge")]
        [RegularExpression(@"[0-9a-zA-Z\s]{1,30}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "LCTErrorRegExLabourCharge")]
        public override string LabourCharge{ get; set; }
    }
}
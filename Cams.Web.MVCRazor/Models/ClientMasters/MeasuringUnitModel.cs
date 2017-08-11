using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientMasters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cams.Web.MVCRazor.Models.ClientMasters
{
    public class MeasuringUnitModel : MeasuringUnitDto
    {
        public MeasuringUnitModel()
        {
            MeasuringUnitList = new List<MeasuringUnitDto>();
        }

        public List<MeasuringUnitDto> MeasuringUnitList;

        [RegularExpression(@"[0-9a-zA-Z\s]{1,20}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "MURegExMeasurementUnit")]
        public string MeasurementUnitWeight { get; set; }

        [RegularExpression(@"^[+]?\d*(\.\d+)?$", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "MURegExEquivalentUnit")]
        public string EquivalentUnitWeight { get; set; }

        [RegularExpression(@"[0-9a-zA-Z\s]{1,20}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "MURegExMeasurementUnit")]
        public string MeasurementUnitQuantity { get; set; }

        [RegularExpression(@"^[+]?\d*(\.\d+)?$", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "MURegExEquivalentUnit")]
        public string EquivalentUnitQuantity { get; set; }
    }
}
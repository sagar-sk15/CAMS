using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cams.Web.MVCRazor.Models
{
    public class ContactDetailsModel : ContactDetailsDto
    {
        public ContactDetailsModel()
        {

        }

        [RegularExpression(@"\d{10}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "URErrorRegExMobileNumber")]
        public override string ContactNo { get; set; }

        [DefaultValue("+91")]
        public override string CountryCallingCode { get; set; }
    }
}
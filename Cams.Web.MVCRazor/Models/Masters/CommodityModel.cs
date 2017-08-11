using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Cams.Common.Dto.Masters;
using System.ComponentModel.DataAnnotations;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Web.MVCRazor.Models.Masters
{
    public class CommodityModel : CommodityDto
    {
        public CommodityModel()
        {
            CommodityClassList = new List<CommodityClassDto>();
            CommodityList = new List<CommodityDto>();
            IsActive = true;
        }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CommmodityRequiredCommodityClassId")]
        public int CommodityClassId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CommodityRequiredName")]
        [RegularExpression(@"^[a-zA-Z0-9&,'\(\)\.\s-]{1,60}$", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CommodityRegXName")]
        public override string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CommodityRequiredBotnicalName")]
        [RegularExpression(@"^[a-zA-Z0-9&,'\(\)\.\s-]{1,60}$", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "CommodityRegXBotnicalName")]
        public override string BotanicalName { get; set; }

        public IList<CommodityClassDto> CommodityClassList;
        public IList<CommodityDto> CommodityList;
    }
}
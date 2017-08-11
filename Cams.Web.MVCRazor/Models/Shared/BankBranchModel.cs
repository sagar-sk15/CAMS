using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.Address;
using Cams.Common.Dto;
using System.ComponentModel.DataAnnotations;
using Cams.Common;

namespace Cams.Web.MVCRazor.Models.Shared
{
    public class BankBranchModel : BankBranchDto
    {
        public BankBranchModel()
        {
            BranchAddress = new AddressDto();
            BranchContactNos = new List<ContactDetailsDto>();
            BranchContactNos.Add(
                                 new ContactDetailsDto()
                                     {
                                         ContactNoType = Common.ContactType.MobileNo,
                                         ContactNo = "",
                                         STDCode = "020",
                                         CountryCallingCode = "+91"
                                     }
                             );
            BranchOfBank = new BankDto();
            WeeklyOffDay = new WeeklyOffDaysDto();
            WeeklyHalfDay = new WeeklyHalfDayDto();
            FullDayTimeFrom = new TimeSpan(9, 0, 0);
            FullDayTimeTo = new TimeSpan(6, 30, 0);
            FullDayBreakFrom = new TimeSpan(12, 30, 0);
            FullDayBreakTo = new TimeSpan(13, 15, 0);
            HalfDayTimeFrom = new TimeSpan(9, 0, 0);
            HalfDayTimeTo = new TimeSpan(16, 0, 0);
            HalfDayBreakFrom = new TimeSpan(12, 30, 0);
            HalfDayBreakTo = new TimeSpan(13, 15, 0);
            StateDistrictPlacesControlNames = new StateDistrictCityControlNamesModel("");
            StateDistrictPlacesControlNames.LeftLabelsClassName = "width80";
        }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBRequiredBranchName")]
        [RegularExpression(@"^[a-zA-Z0-9&,'\(\)\.\s-]{1,60}$", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBErrorRegExBranchName")]
        public override string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBRequiredIFSC")]
        [RegularExpression(Constants.REGXIFSCCODE, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBErrorRegExIFSC")]
        public override string IFSCCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBRequiredSWIFT")]
        [RegularExpression(Constants.REGXSWIFTCODE, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBErrorRegExSWIFT")]
        public override string SWIFTCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBRequiredMICR")]
        [RegularExpression(Constants.REGXMICRCODE, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBErrorRegExMICR")]
        public override string MICRCode { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBRequiredEmail1")]
        [RegularExpression(Constants.REGEXEMAIL, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBErrorRegExEmail1")]
        public override string Email1 { get; set; }

        [RegularExpression(Constants.REGEXEMAIL, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "BBErrorRegExEmail2")]
        public override string Email2 { get; set; }

        public string FullDayBreakFromString;
        public string FullDayBreakToString;
        public string FullDayTimeFromString;
        public string FullDayTimeToString;
        public string HalfDayBreakFromString;
        public string HalfDayBreakToString;
        public string HalfDayTimeFromString;
        public string HalfDayTimeToString;
        public StateDistrictCityControlNamesModel StateDistrictPlacesControlNames;
    }
}
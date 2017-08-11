using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.Masters;

namespace Cams.Web.MVCRazor.Models.Masters
{
    public class CountryModel : CountryDto
    {
        public override string CountryName { get; set; }
        public override string CallingCode { get; set; }
        public override int AgeStd { get; set; }
        public override string Currency { get; set; }
        public override string CurrencyCode { get; set; }
        public override string Symbol { get; set; }
        public override string TimeZone { get; set; }
        public override string FinancialYearStart { get; set; }
        public override string FinancialYearEnd { get; set; }
        public override string Status { get; set; }
    }
}
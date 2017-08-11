using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Masters
{
    public class CountryDto : DtoBase
    {
        public CountryDto() 
        {
            States = new List<StateDto>();
        }
        public virtual int CountryId { get; set; }
        public virtual string CountryName { get; set; }
        public virtual string CallingCode { get; set; }
        public virtual int AgeStd { get; set; }
        public virtual string Currency { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string Symbol { get; set; }
        public virtual string TimeZone { get; set; }
        public virtual string FinancialYearStart { get; set; }
        public virtual string FinancialYearEnd { get; set; }
        public virtual string Status { get; set; }
        public virtual IList<StateDto> States { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Masters
{
    public class CountryMaster:EntityBase<int>
    {
        public CountryMaster() { }
        public virtual int Id { get; set; }
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

        protected override void Validate()
        {
           
        }
    }
}

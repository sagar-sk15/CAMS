using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto
{
    public class WeekDaysDto:DtoBase
    {
        #region Constructor
        public WeekDaysDto()
        {            
        }
        #endregion

        #region properties        
        public virtual bool IsMonday { get; set; }
        public virtual bool IsTuesday { get; set; }
        public virtual bool IsWednesday { get; set; }
        public virtual bool IsThursday { get; set; }
        public virtual bool IsFriday { get; set; }
        public virtual bool IsSaturday { get; set; }
        public virtual bool IsSunday { get; set; }               
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities
{
    public class WeekDays:EntityBase<int>
    {
        #region Constructor
        public WeekDays()
        {
            
        }
        #endregion

        #region properties
        //public virtual int WeekDayId { get; set; }
        public virtual bool IsMonday { get; set; }
        public virtual bool IsTuesday { get; set; }
        public virtual bool IsWednesday { get; set; }
        public virtual bool IsThursday { get; set; }
        public virtual bool IsFriday { get; set; }
        public virtual bool IsSaturday { get; set; }
        public virtual bool IsSunday { get; set; }
               

        #endregion

        #region Methods
        public override void Validate()
        {
            return;
        }
        #endregion
    }
}

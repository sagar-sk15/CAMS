using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Domain.Entities
{
    public class WeeklyHalfDay: WeekDays
    {
        #region Constructor
        public WeeklyHalfDay()
        {
        }
        #endregion 

        #region properties
        public virtual int WeeklyHalfDayId { get; set; }        
        public virtual BankBranch WeeklyHalfDayOfBranch { get; set; }        
        #endregion 

    }
}

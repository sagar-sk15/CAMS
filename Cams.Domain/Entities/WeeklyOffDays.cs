using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientMasters;

namespace Cams.Domain.Entities
{
    public class WeeklyOffDays:WeekDays
    {
        #region Constructor
        public WeeklyOffDays()
        {
        }
        #endregion 

        #region properties
        public virtual int WeeklyOffDayId { get; set; }
        public virtual BankBranch WeeklyOffDayOfBranch { get; set; }         
        #endregion 
    }
}

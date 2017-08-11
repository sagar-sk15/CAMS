using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Common.Dto
{
    public class WeeklyHalfDayDto:WeekDaysDto
    {
        #region Constructor
        public WeeklyHalfDayDto()
        {
        }
        #endregion 

        #region properties
        public virtual int WeeklyHalfDayId { get; set; }        
        public virtual BankBranchDto WeeklyHalfDayOfBranch { get; set; }        
        #endregion 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Common.Dto
{
    public class WeeklyOffDaysDto : WeekDaysDto
    {
        #region Constructor
        public WeeklyOffDaysDto()
        {
        }
        #endregion 

        #region properties
        public virtual int WeeklyOffDayId { get; set; }
        public virtual BankBranchDto WeeklyOffDayOfBranch { get; set; }         
        #endregion 
    }
}

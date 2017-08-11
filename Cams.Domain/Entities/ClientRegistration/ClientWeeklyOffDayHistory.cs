using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientWeeklyOffDayHistory : WeekDays
    {
        #region Constructor
        public ClientWeeklyOffDayHistory()  
        {
            
        }
        #endregion

        #region Properties
        public virtual int ClientWeeklyOffDayHistoryId { get; set; }
        public virtual int CAId { get; set; }
        public virtual DateTime WithEffectFromDate { get; set; }
        public virtual DateTime WithEffectToDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

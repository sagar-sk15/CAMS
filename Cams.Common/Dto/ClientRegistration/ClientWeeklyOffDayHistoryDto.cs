using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public  class ClientWeeklyOffDayHistoryDto : DtoBase
    {
        #region Constructor
        public ClientWeeklyOffDayHistoryDto()  
        {
            WithEffectFromDate = Helper.SetDefaultDate();
            WithEffectToDate = Helper.SetDefaultDate();
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

    }
}

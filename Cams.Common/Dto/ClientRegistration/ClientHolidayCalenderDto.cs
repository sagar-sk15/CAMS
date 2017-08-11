using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientHolidayCalenderDto : DtoBase
    {
        #region Constructor
        public ClientHolidayCalenderDto() 
        {
            HolidayFromDate = Helper.SetDefaultDate();
            HolidayToDate = Helper.SetDefaultDate();
        }
        #endregion

        #region properties

        public virtual int ClientHolidayCalenderId { get; set; }
        public virtual int CAId { get; set; }
        public virtual DateTime HolidayFromDate { get; set; }
        public virtual Nullable<DateTime> HolidayToDate { get; set; }
        public virtual string Reason { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }           

        #endregion
    }
}

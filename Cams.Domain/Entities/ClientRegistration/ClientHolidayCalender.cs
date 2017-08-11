using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientHolidayCalender : EntityBase<int> 
    {
        #region Constructor
        public ClientHolidayCalender()  
        {
            
        }
        #endregion

        #region Properties
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

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

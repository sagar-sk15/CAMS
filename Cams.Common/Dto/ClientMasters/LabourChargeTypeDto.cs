using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientMasters
{
    public class LabourChargeTypeDto : DtoBase
    {

        #region Constructor
        public LabourChargeTypeDto()
        {
        }
        #endregion

        #region properties

        public virtual int LabourChargeId { get; set; }
        public virtual string LabourCharge { get; set; }
        //public virtual string Derivative1 { get; set; }
        //public virtual string Derivative2 { get; set; }
        //public virtual bool IsActive { get; set; }
        public virtual int CAId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        //public virtual ChargesPayableToDto LabourChargesPayableTo { get; set; }
        //public virtual ChargesPayableToDto D1PayableTo { get; set; }
        //public virtual ChargesPayableToDto D2PayableTo { get; set; }
        #endregion
    }
}

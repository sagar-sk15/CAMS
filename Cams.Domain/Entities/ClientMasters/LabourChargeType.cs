using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientMasters
{
    public class LabourChargeType : EntityBase<int>
    {
         #region Constructor
        public LabourChargeType()
        {            
        }
        #endregion 

        #region properties

        public virtual int LabourChargeId { get; set; }
        public virtual string LabourCharge { get; set; }
        //public virtual string Derivative1 { get; set; }
        //public virtual string Derivative2 { get; set; }
        //public virtual bool IsActive { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        //public virtual ChargesPayableTo LabourChargesPayableTo { get; set; }
        //public virtual ChargesPayableTo D1PayableTo { get; set; }
        //public virtual ChargesPayableTo D2PayableTo { get; set; }
        #endregion 

        #region Methods
        public override void Validate()
        {
            return;
        }
        #endregion 
    }
}

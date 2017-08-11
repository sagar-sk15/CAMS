using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientMasters
{
    public class ChargesPayableTo : EntityBase<int>
    {
        #region Constructor
        public ChargesPayableTo()
        {
            LabourCharges = new List<LabourChargeType>();
            D1LabourCharges = new List<LabourChargeType>();
            D2LabourCharges = new List<LabourChargeType>();
        }
        #endregion 

        #region properties

        public virtual int ChargesPayableToId { get; set; }
        public virtual string PayableTo { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<LabourChargeType> LabourCharges { get; set; }
        public virtual IList<LabourChargeType> D1LabourCharges { get; set; }
        public virtual IList<LabourChargeType> D2LabourCharges { get; set; }
        #endregion

        #region Methods

        public override void Validate()
        {
            return;
        }

        #endregion 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientMasters
{
    public class MeasuringUnit : EntityBase<int>
    {
        #region Constructor
        public MeasuringUnit()
        {            
        }
        #endregion 

        #region properties

        public virtual int UnitId { get; set; }
        public virtual Common.UnitType UnitType { get; set; }
        public virtual string MeasurementUnit { get; set; }
        public virtual string EquivalentUnit { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        #endregion 

        #region Methods
        public override void Validate()
        {
            return;
        }
        #endregion 
    }
}

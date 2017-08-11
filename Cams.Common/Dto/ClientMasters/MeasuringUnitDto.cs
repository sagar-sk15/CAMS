using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common;
using System.Runtime.Serialization;

namespace Cams.Common.Dto.ClientMasters
{
    [DataContract]
    [KnownType(typeof(Common.UnitType))]
    public class MeasuringUnitDto : DtoBase
    {
        #region Constructor
        public MeasuringUnitDto()
        {
        }
        #endregion

        #region properties
        [DataMember]
        public virtual int UnitId { get; set; }
        [DataMember]
        public virtual Common.UnitType UnitType { get; set; }
        [DataMember]
        public virtual string MeasurementUnit { get; set; }
        [DataMember]
        public virtual string EquivalentUnit { get; set; }
        [DataMember]
        public virtual int CAId { get; set; }
        [DataMember]
        public virtual long CreatedBy { get; set; }
        [DataMember]
        public virtual DateTime CreatedDate { get; set; }
        [DataMember]
        public virtual System.Nullable<long> ModifiedBy { get; set; }
        [DataMember]
        public virtual System.Nullable<System.DateTime> ModifiedDate { get; set; }

        #endregion
    }
}

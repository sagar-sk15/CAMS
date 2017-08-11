using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Masters
{
    public class ZoneDto: DtoBase
    {
        #region Constructor
        public ZoneDto()
        {
        }
        #endregion

        #region Properties

        public virtual long ZoneId { get; set; }
        public virtual Common.ZoneFor ZoneFor { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        #endregion
    }
}

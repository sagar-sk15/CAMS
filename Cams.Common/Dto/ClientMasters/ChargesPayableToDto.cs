using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientMasters
{
    public class ChargesPayableToDto : DtoBase
    {
        #region Constructor
        public ChargesPayableToDto()
        {
        }
        #endregion

        #region properties

        public virtual int ChargesPayableToId { get; set; }
        public virtual string PayableTo { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<LabourChargeTypeDto> LabourCharges { get; set; }
        public virtual IList<LabourChargeTypeDto> D1LabourCharges { get; set; }
        public virtual IList<LabourChargeTypeDto> D2LabourCharges { get; set; }
        #endregion
    }
}

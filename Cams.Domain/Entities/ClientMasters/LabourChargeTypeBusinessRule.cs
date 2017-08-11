using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.ClientMasters
{
    class LabourChargeTypeBusinessRule
    {
        public static readonly BusinessRule CheckLabourChargeTypePresence = new BusinessRule(Constants.LABOURCHARGE, Constants.BRLABOURCHARGEVALIDATION);
        public static readonly BusinessRule CheckActiveLabourChargeTypes = new BusinessRule(Constants.LABOURCHARGEID, Constants.BRLABOURCHARGEALLOWEDVALIDATION);
    }
}

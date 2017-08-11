using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.ClientMasters
{
    public class CommodityBusinessRule
    {
        public static readonly BusinessRule CheckCommodityPresence = new BusinessRule(Constants.COMMODITYNAME, Constants.BRCOMMODITYNAMEVALIDATION);
        public static readonly BusinessRule CheckBotanicalNamePresence = new BusinessRule(Constants.BOTANICALNAME, Constants.BRBOTANICALNAMEVALIDATION);
    }
}

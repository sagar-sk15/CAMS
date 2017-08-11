using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.Masters
{
    public class MastersBusinessRule
    {
        // added only state businessrules
        public static readonly BusinessRule CheckStatePresence = new BusinessRule(Constants.REGIONNAME, Constants.BRSTATEVALIDATION);
    }

    public class DistrictBusinessRule
    {
        public static readonly BusinessRule CheckDistrictPresence = new BusinessRule(Constants.DISTRICTNAME, Constants.BRDISTRICTNAMEVALIDATION);
    }

    public class CityVillageBusinessRule
    {
        public static readonly BusinessRule CheckCityVillagePresence = new BusinessRule(Constants.CITYVILLAGENAME, Constants.BRCITYVILLAGEVALIDATION);
    }

    public class ZoneBusinessRule
    {
        public static readonly BusinessRule CheckZonePresence = new BusinessRule(Constants.ZONENAME, Constants.BRZONENAMEVALIDATION);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.ClientMasters
{
    public class ClientMasterBusinessRule
    {
        public static readonly BusinessRule CheckMUMeasurementUnit = new BusinessRule(Constants.MEASUREMENTUNIT, Constants.BRMUMEASURINGUNITVALIDATION);
    }

    public class BankBusinessRule
    {
        public static readonly BusinessRule CheckBankPresence = new BusinessRule(Constants.BANKNAME, Constants.BRBANKNAMEVALIDATION);        
    }

    public class BankBranchBusinessRule
    {
        public static readonly BusinessRule CheckBankBranchPresence = new BusinessRule(Constants.BANKBRANCHNAME, Constants.BRBANKBRANCHNAMEVALIDATION);
        public static readonly BusinessRule CheckIFSCCodePresence = new BusinessRule(Constants.IFSCCODE, Constants.BRIFSCCODE);
        public static readonly BusinessRule CheckMICRCodePresence = new BusinessRule(Constants.MICRCODE, Constants.BRMICRCODE);
        public static readonly BusinessRule CheckSWIFTCodePresence = new BusinessRule(Constants.SWIFTCODE, Constants.BRSWIFTCODE);          
    }
}

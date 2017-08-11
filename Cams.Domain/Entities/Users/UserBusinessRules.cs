using System;
using System.Linq;
using Cams.Common;

namespace Cams.Domain.Entities.Users
{
    public class UserBusinessRules
    {
        //replace the strings with resource key entries
        public static readonly BusinessRule UsernameRequired = new BusinessRule("Username", Constants.BRUSERNAME);
        public static readonly BusinessRule PasswordRequired = new BusinessRule("Password", Constants.BRPASSWORD);
        public static readonly BusinessRule EmailRequired = new BusinessRule("Email", Constants.BREMAIL);
        public static readonly BusinessRule Name = new BusinessRule("Name", Constants.BRNAME);
        public static readonly BusinessRule MothersMaidenName = new BusinessRule("MothersMaidenName", Constants.BRMOTHERSMAIDENNAME);
        public static readonly BusinessRule MobileNo = new BusinessRule("MobileNo",Constants.BRMOBILENO);
        public static readonly BusinessRule DateOfBirth = new BusinessRule("DateOfBirth", Constants.BRDATEOFBIRTH);

    }
}

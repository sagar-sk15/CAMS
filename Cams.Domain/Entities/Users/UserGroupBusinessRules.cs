using System;
using System.Linq;
using Cams.Common;

namespace Cams.Domain.Entities.Users
{
    public class UserGroupBusinessRules
    {
        //replace the strings with resource key entries
        public static readonly BusinessRule UserGroupNameRequired = new BusinessRule("UserGroupNameRequired", Constants.BRUSERGROUPNAMEREQUIRED);
        public static readonly BusinessRule UserGroupNameUnique = new BusinessRule("UserGroupNameUnique", Constants.BRUSERGROUPNAMEUNIQUE);
     }
}

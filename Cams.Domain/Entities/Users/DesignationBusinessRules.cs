using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.Users
{
    public class DesignationBusinessRules
    {
        public static readonly BusinessRule DesignationNameRequired = new BusinessRule("DesignationNameRequired",Constants.BRDESIGNATIONNAME);
        public static readonly BusinessRule DesignationNameUnique = new BusinessRule("DesignationNameUnique", Constants.BRDESIGNATIONUNIQUE);
    }
}

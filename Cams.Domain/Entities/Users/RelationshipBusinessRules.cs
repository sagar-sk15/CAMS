using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;

namespace Cams.Domain.Entities.Users
{
    public class RelationshipBusinessRules
    {
        public static readonly BusinessRule RelationshipNameRequired = new BusinessRule("RelationshipNameRequired", Constants.BRRELATIONSHIPNAME);
        public static readonly BusinessRule RelationshipNameUnique = new BusinessRule("RelationshipNameUnique", Constants.BRRELATIONSHIPUNIQUE);
    }
}

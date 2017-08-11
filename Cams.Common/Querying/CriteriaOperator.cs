using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Common.Querying
{
    public enum CriteriaOperator
    {
        Equal,
        LesserThanOrEqual,
        GreaterThanOrEqual,
        LesserThan,
        GreaterThan,
        NotEqual,
        IsNullOrZero,
        IsNotNullOrZero,
        In,
        NotIn,
        Like,
        NotLike,
        NotApplicable
        // TODO: Implement remainder of the criteria operators...
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Common.Querying
{
    public enum QueryOperator
    {
        And,
        Or            
    }

    public enum JoinType
    {
        None = -666,
        InnerJoin = 0,
        LeftOuterJoin = 1,
        RightOuterJoin = 2,
        FullJoin = 4,
    }
}

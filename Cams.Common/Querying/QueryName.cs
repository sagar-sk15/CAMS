using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Common.Querying
{
    public enum QueryName
    {       
        Dynamic = 0,
        FindAllActorsByGenreId = 1,
        FindAllGenresByActorId,
        FindAllMoviesByGenreId
    }
}

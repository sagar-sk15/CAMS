using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.AppServices
{
    public class Container
    {
        public static IGlobalContext GlobalContext
        {
            get
            {
                return AppServices.GlobalContext.Instance();
            }
        }

        public static IRequestContext RequestContext { get; set; }
    }
}

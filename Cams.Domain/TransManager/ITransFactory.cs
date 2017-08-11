using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.TransManager
{
    public interface ITransFactory
    {
        ITransManager CreateManager ();
    }
}

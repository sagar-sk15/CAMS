using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.TransManager;

namespace Cams.Domain.AppServices
{
    public interface IGlobalContext
    {
        ITransFactory TransFactory { get; }        
    }
}

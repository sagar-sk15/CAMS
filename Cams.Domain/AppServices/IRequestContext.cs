using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.AppServices
{
    public interface IRequestContext
    {
        IBusinessNotifier Notifier { get; }
    }
}

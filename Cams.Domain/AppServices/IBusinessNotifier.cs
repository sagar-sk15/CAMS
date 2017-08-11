using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Domain.AppServices
{

    public interface IBusinessNotifier
    {
        void AddWarning(BusinessWarningEnum warningType, string message);
        bool HasWarnings { get; }
        IEnumerable<BusinessWarning> RetrieveWarnings();
    }
}

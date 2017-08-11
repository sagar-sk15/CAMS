using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Domain.AppServices
{

    public class BusinessNotifier : IBusinessNotifier
    {
        private readonly IList<BusinessWarning> WarningList = new List<BusinessWarning>();

        #region Implementation of IBusinessNotifier

        public void AddWarning(BusinessWarningEnum warningType, string message)
        {
            WarningList.Add(new BusinessWarning(warningType, message));
        }

        public bool HasWarnings
        {
            get { return WarningList.Count > 0; }
        }

        public IEnumerable<BusinessWarning> RetrieveWarnings()
        {
            if (!HasWarnings) return null;
            var results = WarningList.ToList();
            WarningList.Clear();
            return results;
        }

        #endregion
    }
}

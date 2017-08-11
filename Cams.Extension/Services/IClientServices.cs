using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.ServiceContract;

namespace Cams.Extension.Services
{
    interface IClientServices
    {
        IContractLocator ContractLocator { get; }
    }
}

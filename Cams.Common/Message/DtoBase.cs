using System.Linq.Expressions;
using System.Text;
using System.Runtime.Serialization;

namespace Cams.Common.Message
{
    [DataContract]
    [KnownType(typeof(Common.UnitType))]
    public abstract class DtoBase
        : IDtoResponseEnvelop
    {
        #region IDtoResponseEnvelop Members

        [DataMember]
        private readonly Response ResponseInstance = new Response();
        public Response Response
        {
            get { return ResponseInstance; }
        }

        #endregion
    }
}

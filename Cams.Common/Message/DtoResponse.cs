using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cams.Common.Message
{

    [DataContract]
    public sealed class DtoResponse
        : IDtoResponseEnvelop
    {
        public DtoResponse() : this(0) { }

        public DtoResponse(long entityId)
        {
            ResponseInstance = new Response(entityId);
        }     

        [DataMember]
        private readonly Response ResponseInstance;
        
        public Response Response
        {
            get { return ResponseInstance; }
        }
    }
}

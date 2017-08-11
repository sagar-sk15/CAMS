using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cams.Common.Message
{

    [DataContract]
    public class BusinessExceptionDto
    {
        protected BusinessExceptionDto() { }

        public BusinessExceptionDto(BusinessExceptionEnum type, string message, string stackTrace)
        {
            ExceptionType = type;
            Message = message;
            StackTrace = stackTrace;
        }

        [DataMember]
        public BusinessExceptionEnum ExceptionType { get; private set; }
        [DataMember]
        public string Message { get; private set; }
        [DataMember]
        public string StackTrace { get; private set; }
    }
}

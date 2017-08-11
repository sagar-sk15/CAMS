using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Common.Message
{
 
    public class BusinessException : ApplicationException
    {
        public BusinessException(BusinessExceptionEnum businessExceptionType, string message)
            : base(message)
        {
            ExceptionType = businessExceptionType;
        }

        public BusinessExceptionEnum ExceptionType { get; set; }
    }
}

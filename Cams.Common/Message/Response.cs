using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Cams.Common.Message
{

    [DataContract]
    public class Response
    {        
        #region Constructors

        public Response():this(0){}

        public Response(long entityId)
        {
            EntityIdInstance = entityId;
        }

        #endregion        
        #region Private Serializable Members

        [DataMember]
        private BusinessExceptionDto BusinessExceptionInstance;

        [DataMember]
        private readonly IList<BusinessWarning> BusinessWarningList = new List<BusinessWarning>();
        
        [DataMember]
        private readonly long EntityIdInstance;

        #endregion
        #region Public Methods

        public void AddBusinessException(BusinessException exception)
        {
            BusinessExceptionInstance = new BusinessExceptionDto(exception.ExceptionType, exception.Message, exception.StackTrace);
        }
        
        public void AddBusinessWarnings(IEnumerable<BusinessWarning> warnings)
        {
            warnings.ToList().ForEach( w => BusinessWarningList.Add(w));
        }

        #endregion
        #region Public Getters

        public bool HasWarning
        {
            get { return BusinessWarningList.Count > 0; }
        }

        public IEnumerable<BusinessWarning> BusinessWarnings
        {
            get { return new ReadOnlyCollection<BusinessWarning>(BusinessWarningList); }
        }

        public long EntityId
        {
            get { return EntityIdInstance; }
        }

        public bool HasException
        {
            get { return BusinessExceptionInstance != null; }
        }

        public BusinessExceptionDto BusinessException
        {
            get { return BusinessExceptionInstance; }
        }

        #endregion
    }
}

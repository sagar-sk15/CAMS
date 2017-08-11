using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Email
{
    public class ClientProfileChangeRequestsDto : DtoBase
    {
        #region Constructor
        public ClientProfileChangeRequestsDto()
        {
            ClientProfileChangeRequestFields = new List<ClientProfileChangeRequestFieldsDto>();
        }
        #endregion

        #region Properties

        public virtual int RequestId { get; set; }
        public virtual string Reason { get; set; }
        public virtual int CAId { get; set; }
        public virtual Common.ClientProfileChangeRequestStatus ClientProfileChangeRequestStatus { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }

        public virtual EmailMessagesDto ClientProfileChangeRequestEmailMessages { get; set; }
        public virtual IList<ClientProfileChangeRequestFieldsDto> ClientProfileChangeRequestFields { get; set; }
        #endregion
    }
}

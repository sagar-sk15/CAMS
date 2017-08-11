using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Email
{
    public class ClientProfileChangeRequestFieldsDto : DtoBase
    {
        #region Constructor
        public ClientProfileChangeRequestFieldsDto()
        {
            ClientProfileChangeRequests = new List<ClientProfileChangeRequestsDto>();
        }
        #endregion

        #region Properties

        public virtual int ClientProfileCRFieldId { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string CurrentValue { get; set; }
        public virtual string NewValue { get; set; }
        public virtual string FieldOfValue { get; set; }
        public virtual string ObjectNameInDomainEntity { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }

        public virtual IList<ClientProfileChangeRequestsDto> ClientProfileChangeRequests { get; set; }
        #endregion
    }
}

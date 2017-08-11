using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Email
{
    public class ClientProfileChangeRequests : EntityBase<int>
    {
        #region Constructor
        public ClientProfileChangeRequests()
        {
            ClientProfileChangeRequestFields = new List<ClientProfileChangeRequestFields>();
        }
        #endregion

        #region Properties

        public virtual int RequestId { get; set; }
        public virtual string Reason { get; set; }
        public virtual int CAId { get; set; }
        public virtual Common.ClientProfileChangeRequestStatus ClientProfileChangeRequestStatus { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }

        public virtual EmailMessages ClientProfileChangeRequestEmailMessages { get; set; }
        public virtual IList<ClientProfileChangeRequestFields> ClientProfileChangeRequestFields { get; set; }
        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

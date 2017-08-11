using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Email
{
    public class ClientProfileChangeRequestFields : EntityBase<int>  
    {
        #region Constructor
        public ClientProfileChangeRequestFields()
        {
            ClientProfileChangeRequests = new List<ClientProfileChangeRequests>();
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

        public virtual IList<ClientProfileChangeRequests> ClientProfileChangeRequests { get; set; }
        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

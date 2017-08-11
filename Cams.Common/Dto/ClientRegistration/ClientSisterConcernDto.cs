using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientSisterConcernDto : DtoBase
    {
        #region Constructor
        public ClientSisterConcernDto() 
        {
            SisterConcernOfClient = new List<ClientDto>();      
        }
        #endregion

        #region Properties

        public virtual int ClientSisterConcernId { get; set; }
        public virtual Common.ClientSisterConcernBusinessRelation BusinessRelation { get; set; }
        public virtual string ClientSisterConcerName { get; set; }
        public virtual string RelationshipWithEntity { get; set; }
        public virtual Nullable<int> EntityId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }

        public virtual IList<ClientDto> SisterConcernOfClient { get; set; } 
        #endregion 
    }
}

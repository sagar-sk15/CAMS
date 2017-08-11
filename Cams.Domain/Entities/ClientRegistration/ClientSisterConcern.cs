using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientSisterConcern : EntityBase<int> 
    {
        #region Constructor
        public ClientSisterConcern() 
        {
            SisterConcernOfClient = new List<Client>();      
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

        public virtual IList<Client> SisterConcernOfClient { get; set; } 
        #endregion 

        #region Methods
        public override void Validate()
        {
        }
        #endregion
    }
}

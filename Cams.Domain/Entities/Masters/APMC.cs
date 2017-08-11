using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities.ClientRegistration;

namespace Cams.Domain.Entities.Masters
{
    public class APMC : EntityBase<long>
    {
        #region Constructor
        public APMC()
        {
            ContactNos = new List<ContactDetails>();
            APMCOfClients = new List<Client>();
        }
        #endregion 

        #region properties
        public virtual int APMCId { get; set; }
        public virtual Address Address { get; set; }
        public virtual IList<ContactDetails> ContactNos { get; set; }
        public virtual IList<Client> APMCOfClients { get; set; }
        public virtual string Name { get; set; }
        public virtual string Status { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual string Website { get; set; }
        #endregion 

        #region Overrides of EntityBase<long>

        public override void Validate()
        {

        }
                
        #endregion
    }
}

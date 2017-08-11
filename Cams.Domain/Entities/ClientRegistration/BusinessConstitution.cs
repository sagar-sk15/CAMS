using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class BusinessConstitution : EntityBase<int>
    {
        #region Constructor
        public BusinessConstitution() 
        {
            BusinessConstitutionOfClients = new List<Client>();
        }
        #endregion

        #region properties
        public virtual int BusinessConstitutionId { get; set; }
        public virtual string BusinessConstitutionName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<Client> BusinessConstitutionOfClients { get; set; }
        #endregion 

        #region methods
        public override void Validate()
        {
            return;
        }

        #endregion
    }
}

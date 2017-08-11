using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Message;

namespace Cams.Common.Dto.Masters
{
    public class APMCDto : DtoBase
    {
        #region Constructor
        public APMCDto() 
		{            
            ContactNos = new List<ContactDetailsDto>();
            APMCOfClients = new List<ClientDto>();
		}
        #endregion

        #region properties
        public int APMCId { get; set; }
        public virtual AddressDto  Address{ get; set; }
        public virtual IList<ContactDetailsDto> ContactNos { get; set; }
        public virtual IList<ClientDto> APMCOfClients { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual string Website { get; set; }
        public virtual string Status { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        #endregion 
    }
}

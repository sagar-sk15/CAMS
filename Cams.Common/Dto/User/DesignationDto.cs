using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.Dto.User
{
    public class DesignationDto : DtoBase
    {
        #region Constructor
        public DesignationDto()
        {
            UsersWithDesignation = new List<UserDto>();
            ClientPrimaryContactPersonWithDesignation = new List<ClientPrimaryContactPersonDto>();
            ClientPartnerWithDesignation = new List<ClientPartnerDetailsDto>();
            ClientPartnerBankContactPersonWithDesignation = new List<ClientPartnerBankDetailsDto>();
        }
        #endregion 

        #region Properties
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IList<UserDto> UsersWithDesignation { get; set; }
        public virtual IList<ClientPrimaryContactPersonDto> ClientPrimaryContactPersonWithDesignation { get; set; }
        public virtual IList<ClientPartnerDetailsDto> ClientPartnerWithDesignation { get; set; }
        public virtual IList<ClientPartnerBankDetailsDto> ClientPartnerBankContactPersonWithDesignation { get; set; } 
        #endregion
    }
}

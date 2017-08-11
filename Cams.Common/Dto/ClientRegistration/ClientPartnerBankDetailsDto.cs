using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.User;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPartnerBankDetailsDto : DtoBase
    {
        #region Constructor
        public ClientPartnerBankDetailsDto()  
        {
            BankDetailsOfClient = new List<ClientPartnerDetailsDto>();
            BankContactPersonContacts = new List<ContactDetailsDto>();
        }
        #endregion

        #region Properties

        public virtual int ClientPartnerBankId { get; set; }
        public virtual Common.AccountType Accounttype { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual string StandingInstructions { get; set; }
        public virtual string BankContactPersonName { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual IList<ClientPartnerDetailsDto> BankDetailsOfClient { get; set; }
        public virtual BankBranchDto BranchOfClientPartner { get; set; }
        public virtual DesignationDto BankContactPersonDesignation { get; set; }
        public virtual IList<ContactDetailsDto> BankContactPersonContacts { get; set; } 

        #endregion
    }
}

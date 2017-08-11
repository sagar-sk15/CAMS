using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.User;
using Cams.Common.Dto;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientPartnerDetailsDto:DtoBase
    {
        #region Constructor
        public ClientPartnerDetailsDto() 
        {
            ClientPartners = new List<ClientDto>();
            ClientPartnerContacts = new List<ContactDetailsDto>();
            ClientPartnerBanks = new List<ClientPartnerBankDetailsDto>();
            DateOfBirth = Helper.SetDefaultDate();
            JoiningDate = Helper.SetDefaultDate();
            RelievingDate = Helper.SetDefaultDate();
            IssuedOn = Helper.SetDefaultDate();
            ValidUpTo = Helper.SetDefaultDate();
            AsOnDate = Helper.SetDefaultDate(); 
        }
        #endregion

        #region Properties
        public virtual int PartnerId { get; set; }        
        public virtual string Title { get; set; }
        public virtual string PartnerName { get; set; }
        public virtual string Gender { get; set; }
        public virtual Nullable<DateTime> DateOfBirth { get; set; }
        public virtual string PAN { get; set; }
        public virtual string UID { get; set; }
        public virtual string Image { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual Nullable<DateTime> JoiningDate { get; set; }
        public virtual Nullable<DateTime> RelievingDate { get; set; }

        public virtual string PartnerDisplayId { get; set; }
        public virtual string MaritialStatus { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual string Place { get; set; } // check again
        public virtual Nullable<DateTime> IssuedOn { get; set; }
        public virtual Nullable<DateTime> ValidUpTo { get; set; }
        public virtual Common.PartnerType PartnerType { get; set; }
        public virtual decimal CapitalRatio { get; set; }
        public virtual decimal ProfitRatio { get; set; }
        public virtual decimal SalaryRatio { get; set; }
        public virtual decimal LossRatio { get; set; }
        public virtual decimal OpeningBalance { get; set; }
        public virtual Common.BalanceType BalanceType { get; set; }
        public virtual Nullable<DateTime> AsOnDate { get; set; }  

        public virtual bool IsActive { get; set; }
        public virtual long CreatedBy { get; set; } 
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual AddressDto ClientPartnerAddress { get; set; }
        public virtual DesignationDto ClientPartnerDesignation { get; set; }
        public virtual IList<ClientDto> ClientPartners { get; set; }
        public virtual IList<ContactDetailsDto> ClientPartnerContacts { get; set; }
        public virtual ClientPartnerGuardianDetailsDto ClientPartnerGuardian { get; set; }
        public virtual IList<ClientPartnerBankDetailsDto> ClientPartnerBanks { get; set; }
        public virtual ClientPartnerNomineeDetailsDto ClientPartnerNominee { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Common.Dto.ClientMasters
{
    public class BankBranchDto: DtoBase
    {
        #region Constructor
        public BankBranchDto()
        {
            BranchContactNos = new List<ContactDetailsDto>();
            BranchOfClientSubscriptionPayment = new List<ClientSubscriptionPaymentDetailsDto>();
            BranchOfClientPartner = new List<ClientPartnerBankDetailsDto>();
        }
        #endregion 

        #region properties

        public virtual int BranchId { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual string IFSCCode { get; set; }
        public virtual string MICRCode { get; set; }
        public virtual string SWIFTCode { get; set; }
        public virtual string Email1 { get; set; }
        public virtual string Email2 { get; set; }
        public virtual Nullable<TimeSpan> FullDayTimeFrom { get; set; }
        public virtual Nullable<TimeSpan> FullDayTimeTo { get; set; }
        public virtual Nullable<TimeSpan> HalfDayTimeFrom { get; set; }
        public virtual Nullable<TimeSpan> HalfDayTimeTo { get; set; }
        public virtual Nullable<TimeSpan> FullDayBreakFrom { get; set; }
        public virtual Nullable<TimeSpan> FullDayBreakTo { get; set; }
        public virtual Nullable<TimeSpan> HalfDayBreakFrom { get; set; }
        public virtual Nullable<TimeSpan> HalfDayBreakTo { get; set; }
        public virtual Nullable<int> BaseBranchId { get; set; } 
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        
        public virtual BankDto BranchOfBank { get; set; }
        public virtual Address.AddressDto BranchAddress { get; set; }
        public virtual WeeklyHalfDayDto WeeklyHalfDay { get; set; }
        public virtual WeeklyOffDaysDto WeeklyOffDay { get; set; }
        public virtual IList<ContactDetailsDto> BranchContactNos { get; set; }
        public virtual IList<ClientSubscriptionPaymentDetailsDto> BranchOfClientSubscriptionPayment { get; set; }
        public virtual IList<ClientPartnerBankDetailsDto> BranchOfClientPartner { get; set; }
       

        #endregion
    }
}

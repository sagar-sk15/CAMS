using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientSubscriptionDto:DtoBase
    {
        #region Constructor
        public ClientSubscriptionDto() 
        {
            ClientSubscriptionPaymentDetails = new List<ClientSubscriptionPaymentDetailsDto>();
        }
        #endregion

        #region Properties
        public virtual int ClientSubscriptionId { get; set; }
        public virtual int SubscriptionPeriod { get; set; }
        public virtual Nullable<DateTime> SubscriptionPeriodFromDate { get; set; }
        public virtual Nullable<DateTime> SubscriptionPeriodToDate { get; set; }
        public virtual int AdditionalNoOfEmployees { get; set; }
        public virtual int AdditionalNoOfAuditors { get; set; }
        public virtual int AdditionalNoOfAssociates { get; set; }
        public virtual decimal AdditionalCostForEmployees { get; set; }
        public virtual decimal AdditionalCostForAuditors { get; set; }
        public virtual decimal AdditionalCostForAssociates { get; set; }
        public virtual float DiscountInPercentage { get; set; }
        public virtual decimal DiscountInRupees { get; set; }
        public virtual decimal ServiceTax { get; set; }
        public virtual decimal OtherTax { get; set; }
        public virtual Common.ClientStatus Status { get; set; }
        public virtual string AdditionalInfo { get; set; }
        public virtual Nullable<DateTime> ActivationDate { get; set; }
        public virtual decimal NetAmount { get; set; }
        public virtual bool AllowEdit { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        public virtual SubscriptionMasterDto SubscriptionMaster { get; set; }
        public virtual IList<ClientSubscriptionPaymentDetailsDto> ClientSubscriptionPaymentDetails { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientTaxationAndLicensesDto : DtoBase
    {
        #region Constructor
        public ClientTaxationAndLicensesDto()  
        {
            TaxationAndLicensesofClient = new List<ClientDto>();
            WithEffectFromDate = Helper.SetDefaultDate();
            RenewalDate = Helper.SetDefaultDate();
        }
        #endregion

        #region Properties

        public virtual int ClientTaxationAndLicensesId { get; set; }
        public virtual string TaxName { get; set; }
        public virtual string LicenseNo { get; set; }
        public virtual bool IsWithEffectFromDateApplicable { get; set; } 
        public virtual bool IsRenewalDateApplicable { get; set; }
        public virtual Nullable<DateTime> WithEffectFromDate { get; set; }
        public virtual Nullable<DateTime> RenewalDate { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual System.DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual IList<ClientDto> TaxationAndLicensesofClient { get; set; }
        #endregion
    }
}

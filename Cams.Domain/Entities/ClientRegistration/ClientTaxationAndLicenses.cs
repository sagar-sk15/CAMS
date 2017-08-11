using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.ClientRegistration
{
    public class ClientTaxationAndLicenses : EntityBase<int> 
    {
        #region Constructor
        public ClientTaxationAndLicenses()  
        {
            TaxationAndLicensesofClient = new List<Client>();
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

        public virtual IList<Client> TaxationAndLicensesofClient { get; set; }
        #endregion

        #region Methods

        public override void Validate()
        {

        }
        #endregion
    }
}

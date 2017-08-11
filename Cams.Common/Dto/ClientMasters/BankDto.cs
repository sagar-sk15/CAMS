using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientMasters
{
    public class BankDto:DtoBase
    {
        #region Constructor
        public BankDto()
        {
            Branches = new List<BankBranchDto>();
        }
        #endregion 

        #region properties
        public virtual int BankId { get; set; }
        public virtual string BankName { get; set; }
        public virtual string Alias { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual string URL { get; set; }
        public virtual Nullable<int> BaseBankId { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
        public virtual IList<BankBranchDto> Branches { get; set; }
        #endregion
    }
}

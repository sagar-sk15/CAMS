using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Dto.ClientMasters;

namespace Cams.Domain.Entities.ClientMasters
{
    public class Bank:EntityBase<int>
    {
        #region Constructor
        public Bank()
        {
            Branches = new List<BankBranch>();
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
        public virtual DateTime ModifiedDate { get; set; }
        public virtual IList<BankBranch> Branches { get; set; }
        #endregion

        #region Methods
        public override void Validate()
        {
            return;
        }

        public static bool IsDirty(BankDto bankNewValues, BankDto bankDBValues)
        {
            bool isDirty = false;
            if (bankNewValues.BankId == bankDBValues.BankId)
            {
                if (bankNewValues.BankName != null)
                {
                    if (bankNewValues.BankName != bankDBValues.BankName)
                        isDirty = true;
                    else if (bankNewValues.Alias != bankDBValues.Alias)
                        isDirty = true;
                    else if (bankNewValues.URL != bankDBValues.URL)
                        isDirty = true;
                }
            }
            return isDirty;
        }
        #endregion
    }
}

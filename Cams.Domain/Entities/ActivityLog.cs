using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Repository;

namespace Cams.Domain.Entities
{
    public class ActivityLog : EntityBase<long>
    {
        #region Constructor
        public ActivityLog()
        {

        }
        #endregion

        #region Properties
        public virtual int LogId { get; private set; }
        public virtual string LoggedBy { get; set; }
        public virtual DateTime LoggedDate { get; set; }
        public virtual string ActivityRelatedTo { get; set; }
        public virtual string Description { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual string ObjectId { get; set; } 
        #endregion

        #region Methods
        public override void Validate()
        {
        }

        #endregion
    }


}

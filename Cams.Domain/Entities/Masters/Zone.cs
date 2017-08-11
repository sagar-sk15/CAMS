using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Masters
{
    public class Zone:EntityBase<long>
    {
        #region Constructor
        public Zone()
        {
        }
        #endregion

        #region Properties
        public virtual long ZoneId { get; set; }
        public virtual Common.ZoneFor ZoneFor {get;set;}
        public virtual string Name {get;set;}
        public virtual Nullable<int> CAId { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
            
        #endregion

        #region Methods

        /// <summary>
        /// Validates the user for different businessrules
        /// </summary>
        public override void Validate()
        {
        }
        #endregion 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Masters
{
    public class StatesMaster:EntityBase<int>
    {
        #region Constructor
        public StatesMaster() { }
        #endregion

        #region Properties
        public virtual int Id { get; set; }
        public virtual string Country { get; set; }
        public virtual string RegionType { get; set; }
        public virtual string RegionName { get; set; }
        #endregion

        #region Override the base abstract methods
        protected override void Validate()
        {

        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cams.Domain.Entities.Masters
{
    public class State:EntityBase<int>
    {
        #region Constructor
        public State() {
            DistrictsInState = new List<District>();
        }
        #endregion

        #region Properties
        public virtual int StateId { get; set; }        
        public virtual string RegionType { get; set; }
        public virtual string RegionName { get; set; }
        public virtual Country StateInCountry { get; set; }
        public virtual IList<District> DistrictsInState { get; set; }
        #endregion

        #region Override the base abstract methods
        public override void Validate()
        {

        }
        #endregion
    }
}

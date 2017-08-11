using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.Log
{
    /// <summary>
    /// This class contains the properties required to log the user activities
    /// </summary>
    public class ActivityLogDto : DtoBase
    {
        #region Constructor
        public ActivityLogDto()
        {

        }
        #endregion

        #region Properties
        public string LoggedBy { get; set; }
        public DateTime LoggedDate { get; set; }
        public string ActivityRelatedTo { get; set; }
        public string Description { get; set; }
        public virtual Nullable<int> CAId { get; set; }
        public virtual string ObjectId { get; set; } 
        #endregion
    }
}

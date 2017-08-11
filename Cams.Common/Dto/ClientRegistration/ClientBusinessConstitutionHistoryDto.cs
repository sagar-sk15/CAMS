using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class ClientBusinessConstitutionHistoryDto : DtoBase
    {
        #region Constructor
        public ClientBusinessConstitutionHistoryDto() 
        {           
        }
        #endregion

        #region properties

        public virtual int ClientBusinessConstitutionHistoryId { get; set; }
        public virtual int CAId { get; set; }
        public virtual int BusinessConstitutionId { get; set; }
        public virtual long ModifiedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }      

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto.ClientRegistration
{
    public class BusinessConstitutionDto: DtoBase
    {
        #region Constructor
        public BusinessConstitutionDto()
        {
            BusinessConstitutionOfClients = new List<ClientDto>();
        }
        #endregion 

        #region properties
        public virtual int BusinessConstitutionId { get; set; }
        public virtual string BusinessConstitutionName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<ClientDto> BusinessConstitutionOfClients { get; set; }
        #endregion 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;

namespace Cams.Common.Dto
{
    public class EntityDtos<TEntityDto> : DtoBase
    {
        public IList<TEntityDto> Entities { get; set; }
        public int TotalRecords { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common.Message;


namespace Cams.Common.Dto.User
{
    public class UserUserGroupDto : DtoBase
    {
        public  UserGroupDto UserGroup { get; set; }
        public UserDto User { get; set; }
        public bool IsDeleted { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

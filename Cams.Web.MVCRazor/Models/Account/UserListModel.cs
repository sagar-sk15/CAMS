using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class UserListModel 
    {
       public UserListModel()
        {
            UserList = new List<Cams.Common.Dto.User.UserDto>();
            UserGroupList = new List<Cams.Common.Dto.User.UserGroupDto>();
            ClientList = new List<ClientDto>();
        }

       public IList<Cams.Common.Dto.User.UserDto> UserList;
       public IList<Cams.Common.Dto.User.UserGroupDto> UserGroupList;
       public string SelectedUserGroupList;
       public IList<ClientDto> ClientList;
       public int CAId;
       public string UserName;
       public bool AllowEdit;
    }
}
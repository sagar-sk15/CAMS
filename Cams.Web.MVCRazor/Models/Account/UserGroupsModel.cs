using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.User;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class UserGroupsModel : UserGroupDto
    {
        public UserGroupsModel()
        {
            UserGroupList = new List<UserGroupDto>();
            ClientList = new List<ClientDto>();
        }

        public IList<ClientDto> ClientList;
        public IList<UserGroupDto> UserGroupList;
    }
}
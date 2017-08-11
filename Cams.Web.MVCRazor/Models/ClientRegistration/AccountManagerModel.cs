using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Dto.Masters;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.UserServiceReference;
using Cams.Common.Querying;
using Cams.Common;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public  partial class ClientRegistrationModel : ClientDto
    {
        //public override long AccountManagerId { get; set; }
         public static List<UserDto> GetAccountManagers()
        {
            UserServiceReference.UserServiceClient client = new UserServiceClient();
            Query query = new Query();
            var result = client.GetAccountManagerList();
            List<UserDto> AccountManagers = result.Entities.ToList();
            AccountManagers.Insert(0, new UserDto() { UserId = 0, Name = "[Select]" });
            return AccountManagers;
        }
    }
}
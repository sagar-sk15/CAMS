using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Cams.Common.Dto;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Web.MVCRazor.Models.Account
{
    public class UserGroupModel : Cams.Common.Dto.User.UserGroupDto
    {
        public UserGroupModel()
        {
            Client = new ClientDto();
            IsActive = true;
        }

        [Required(ErrorMessageResourceType = typeof(ClientResources), ErrorMessageResourceName = "UGErrorRequiredGroupName")]
        [RegularExpression(@"[0-9a-zA-Z\s]{1,30}", ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "UGErrorRegExGroupname")]
        public override string UserGroupName { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(ErrorAndValidationMessages), ErrorMessageResourceName = "UGValidateDescription")]
        public override string Description { get; set; }
                
        public override bool AllowEdit { get; set; }

        public override bool AllowDelete { get; set; }

        public override bool IsActive { get; set; }
        
        public override bool IsDeleted { get; set; }

        public ClientDto Client;
    }
}
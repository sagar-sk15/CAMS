using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto;
using Cams.Common.Dto.Address;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.Dto.User;
using Cams.Web.MVCRazor.Models.Shared;

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public partial class ClientRegistrationModel : ClientDto
    {
        public string PCPDesignation { get; set; }
        public List<DesignationModel> designationModel;
        public List<DOBnAgeModel> dOBnAgeModellist;
    }
}
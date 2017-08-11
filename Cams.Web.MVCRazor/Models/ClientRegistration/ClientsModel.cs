using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cams.Common.Dto.ClientRegistration;

namespace Cams.Web.MVCRazor.Models.ClientRegistration
{
    public class ClientsModel
    {
        public ClientsModel()
        {
            Clients = new List<ClientDto>();
        }
        public IList<ClientDto> Clients;
        public int CAId { get; set; }
    }
}
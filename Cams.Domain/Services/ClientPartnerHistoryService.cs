using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities.ClientRegistration;
using Cams.Common.Dto.ClientRegistration;
using Cams.Common.ServiceContract;
using AutoMapper;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ClientPartnerHistoryService : ServiceBase<ClientPartnerHistory, ClientPartnerHistoryDto>, IClientPartnerHistoryService 
    {
        #region Constructor
        public ClientPartnerHistoryService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        
        protected override void CheckForValidations(ClientPartnerHistory clientpartnerhistory) 
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientPartnerHistory clientpartnerhistory) 
        {
        }

        public override ClientPartnerHistoryDto EntityToEntityDto(ClientPartnerHistory entity)
        {
            ClientPartnerHistoryDto clientpartnerhistoryDto = Mapper.Map<ClientPartnerHistory, ClientPartnerHistoryDto>(entity);
            return clientpartnerhistoryDto;
        }

        public override ClientPartnerHistory EntityDtoToEntity(ClientPartnerHistoryDto entityDto)
        {
            ClientPartnerHistory clientpartnerhistory = Mapper.Map<ClientPartnerHistoryDto, ClientPartnerHistory>(entityDto);
            return clientpartnerhistory;
        }

        protected override string GetEntityInstanceName(ClientPartnerHistory clientpartnerhistory)
        {
            return string.Empty;
        }

        #endregion
    }
}

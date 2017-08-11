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
    public class ClientCommoditiesHistoryService : ServiceBase<ClientCommoditiesHistory, ClientCommoditiesHistoryDto>, IClientCommoditiesHistoryService
    {
        #region Constructor
        public ClientCommoditiesHistoryService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientCommoditiesHistory clientcommoditieshistory) 
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientCommoditiesHistory clientcommoditieshistory) 
        {
        }

        public override ClientCommoditiesHistoryDto EntityToEntityDto(ClientCommoditiesHistory entity)
        {
            ClientCommoditiesHistoryDto clientcommoditieshistoryDto = Mapper.Map<ClientCommoditiesHistory, ClientCommoditiesHistoryDto>(entity);
            return clientcommoditieshistoryDto;
        }

        public override ClientCommoditiesHistory EntityDtoToEntity(ClientCommoditiesHistoryDto entityDto)
        {
            ClientCommoditiesHistory clientcommoditieshistory = Mapper.Map<ClientCommoditiesHistoryDto, ClientCommoditiesHistory>(entityDto);
            return clientcommoditieshistory;
        }

        protected override string GetEntityInstanceName(ClientCommoditiesHistory clientcommoditieshistory)
        {
            return string.Empty;
        }

        #endregion
    }
}

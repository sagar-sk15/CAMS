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
    public class ClientPhoneChargesHistoryService : ServiceBase<ClientPhoneChargesHistory, ClientPhoneChargesHistoryDto>, IClientPhoneChargesHistoryService
    {
        #region Constructor
        public ClientPhoneChargesHistoryService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientPhoneChargesHistory clientphonechargeshistory) 
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientPhoneChargesHistory clientphonechargeshistory)  
        {
        }

        public override ClientPhoneChargesHistoryDto EntityToEntityDto(ClientPhoneChargesHistory entity)
        {
            ClientPhoneChargesHistoryDto clientphonechargeshistoryDto = Mapper.Map<ClientPhoneChargesHistory, ClientPhoneChargesHistoryDto>(entity);
            return clientphonechargeshistoryDto;
        }

        public override ClientPhoneChargesHistory EntityDtoToEntity(ClientPhoneChargesHistoryDto entityDto)
        {
            ClientPhoneChargesHistory clientphonechargeshistory = Mapper.Map<ClientPhoneChargesHistoryDto, ClientPhoneChargesHistory>(entityDto);
            return clientphonechargeshistory;     
        }

        protected override string GetEntityInstanceName(ClientPhoneChargesHistory clientphonechargeshistory)  
        {
            return string.Empty;
        }

        #endregion
    }
}

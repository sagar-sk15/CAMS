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
    public class ClientBusinessConstitutionHistoryService : ServiceBase<ClientBusinessConstitutionHistory, ClientBusinessConstitutionHistoryDto>, IClientBusinessConstitutionHistoryService
    {
        #region Constructor
        public ClientBusinessConstitutionHistoryService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientBusinessConstitutionHistory clientbusinessconstitutionhistory) 
        {                      
        }

        protected override void CheckForValidationsWhileUpdating(ClientBusinessConstitutionHistory clientbusinessconstitutionhistory) 
        {
        }

        public override ClientBusinessConstitutionHistoryDto EntityToEntityDto(ClientBusinessConstitutionHistory entity)
        {
            ClientBusinessConstitutionHistoryDto clientbusinessconstitutionhistoryDto = Mapper.Map<ClientBusinessConstitutionHistory, ClientBusinessConstitutionHistoryDto>(entity);
            return clientbusinessconstitutionhistoryDto;
        }

        public override ClientBusinessConstitutionHistory EntityDtoToEntity(ClientBusinessConstitutionHistoryDto entityDto)
        {
            ClientBusinessConstitutionHistory clientbusinessconstitutionhistory = Mapper.Map<ClientBusinessConstitutionHistoryDto, ClientBusinessConstitutionHistory>(entityDto);
            return clientbusinessconstitutionhistory;
        }

        protected override string GetEntityInstanceName(ClientBusinessConstitutionHistory clientbusinessconstitutionhistory) 
        {
            return string.Empty;
        }
        #endregion
    }
}

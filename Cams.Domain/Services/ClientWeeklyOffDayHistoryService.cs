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
    public class ClientWeeklyOffDayHistoryService : ServiceBase<ClientWeeklyOffDayHistory, ClientWeeklyOffDayHistoryDto>, IClientWeeklyOffDayHistoryService
    {
        #region Constructor
        public ClientWeeklyOffDayHistoryService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientWeeklyOffDayHistory clientweeklyoffdayhistory)  
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientWeeklyOffDayHistory clientweeklyoffdayhistory)  
        {
        }

        public override ClientWeeklyOffDayHistoryDto EntityToEntityDto(ClientWeeklyOffDayHistory entity)
        {
            ClientWeeklyOffDayHistoryDto clientweeklyoffdayhistoryDto = Mapper.Map<ClientWeeklyOffDayHistory, ClientWeeklyOffDayHistoryDto>(entity);
            return clientweeklyoffdayhistoryDto;  
        }

        public override ClientWeeklyOffDayHistory EntityDtoToEntity(ClientWeeklyOffDayHistoryDto entityDto)
        {
            ClientWeeklyOffDayHistory clientweeklyoffdayhistory = Mapper.Map<ClientWeeklyOffDayHistoryDto, ClientWeeklyOffDayHistory>(entityDto);
            return clientweeklyoffdayhistory;         
        }

        protected override string GetEntityInstanceName(ClientWeeklyOffDayHistory clientweeklyoffdayhistory) 
        {
            return string.Empty;
        }

        #endregion
    }
}

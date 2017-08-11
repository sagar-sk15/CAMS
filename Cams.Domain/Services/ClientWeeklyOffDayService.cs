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
    public class ClientWeeklyOffDayService : ServiceBase<ClientWeeklyOffDay, ClientWeeklyOffDayDto>, IClientWeeklyOffDayService 
    {
        #region Constructor
        public ClientWeeklyOffDayService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientWeeklyOffDay clientweeklyoffday)   
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientWeeklyOffDay clientweeklyoffday)   
        {
        }

        public override ClientWeeklyOffDayDto EntityToEntityDto(ClientWeeklyOffDay entity)
        {
            ClientWeeklyOffDayDto clientweeklyoffdayDto = Mapper.Map<ClientWeeklyOffDay, ClientWeeklyOffDayDto>(entity);
            return clientweeklyoffdayDto;  
        }

        public override ClientWeeklyOffDay EntityDtoToEntity(ClientWeeklyOffDayDto entityDto)
        {
            ClientWeeklyOffDay clientweeklyoffday = Mapper.Map<ClientWeeklyOffDayDto, ClientWeeklyOffDay>(entityDto);
            return clientweeklyoffday;         
        }

        protected override string GetEntityInstanceName(ClientWeeklyOffDay clientweeklyoffday) 
        {
            return string.Empty;
        }

        #endregion
    }
}

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
    public class ClientHolidayCalenderService : ServiceBase<ClientHolidayCalender, ClientHolidayCalenderDto>, IClientHolidayCalenderService
    {
        #region Constructor
        public ClientHolidayCalenderService()
        {
            
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(ClientHolidayCalender clientholidaycalender)    
        {
        }

        protected override void CheckForValidationsWhileUpdating(ClientHolidayCalender clientholidaycalender)   
        {
        }

        public override ClientHolidayCalenderDto EntityToEntityDto(ClientHolidayCalender entity)
        {
            ClientHolidayCalenderDto clientholidaycalenderDto = Mapper.Map<ClientHolidayCalender, ClientHolidayCalenderDto>(entity);
            return clientholidaycalenderDto;  
        }

        public override ClientHolidayCalender EntityDtoToEntity(ClientHolidayCalenderDto entityDto)
        {
            ClientHolidayCalender clientholidaycalender = Mapper.Map<ClientHolidayCalenderDto, ClientHolidayCalender>(entityDto);
            return clientholidaycalender;         
        }

        protected override string GetEntityInstanceName(ClientHolidayCalender clientholidaycalender)  
        {
            return string.Empty;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Domain.Entities;
using Cams.Common.Dto.Log;
using System.ServiceModel;
using Cams.Domain.AppServices.WcfRequestContext;
using AutoMapper;
using Cams.Domain.Repository;
using Cams.Common.Logging;
using Cams.Common.Dto.User;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class ActivityLogService : ServiceBaseReadOnly<ActivityLog, ActivityLogDto>
    {
        #region Constructor
        public ActivityLogService()
        {

        }
        #endregion

        #region methods
        /// <summary>
        /// This methods logs the activities of the user into ActivityLog Table.
        /// </summary>
        public ActivityLogDto Create(ActivityLogDto entityDto, string userName)
        {
            LoggingFactory.LogInfo("Invoked Create for ActivityLog" );
            return ExecuteCommand(locator => CreateNewCommand(locator, entityDto, userName));
        }

        private ActivityLogDto CreateNewCommand(IRepositoryLocator locator, ActivityLogDto entityDto, string userName)
        {
            ActivityLog logInstance = Mapper.Map<ActivityLogDto, ActivityLog>(entityDto);
            locator.GetRepository<ActivityLog>().Add(logInstance);
            LoggingFactory.LogInfo("ActivityLog Created with ID :" + logInstance.LogId.ToString());
            return Mapper.Map<ActivityLog, ActivityLogDto>(logInstance);
        }
        
        #endregion

        #region Override the base abstract methods

        public override ActivityLog EntityDtoToEntity(ActivityLogDto entityDto)
        {
            ActivityLog activitylog = Mapper.Map<ActivityLogDto, ActivityLog>(entityDto);
            return activitylog;
        }

        public override ActivityLogDto EntityToEntityDto(ActivityLog entity)
        {
            ActivityLogDto activitylogDto = Mapper.Map<ActivityLog, ActivityLogDto>(entity);
            return activitylogDto;
        }
        #endregion 
    }

}

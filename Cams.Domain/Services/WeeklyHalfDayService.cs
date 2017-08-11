using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cams.Common;
using Cams.Common.Dto.ClientMasters;
using Cams.Common.Message;
using Cams.Common.Querying;
using Cams.Common.ServiceContract;
using Cams.Domain.AppServices;
using Cams.Domain.AppServices.WcfRequestContext;
using Cams.Domain.Entities;
using Cams.Domain.Entities.ClientMasters;
using AutoMapper;
using System.ServiceModel;
using Cams.Common.Dto;

namespace Cams.Domain.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [InstanceCreation]
    public class WeeklyHalfDayService : ServiceBase<WeeklyHalfDay, WeeklyHalfDayDto>, IWeeklyHalfDayService
    {
        #region Constructor
        public WeeklyHalfDayService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(WeeklyHalfDay halfday)
        {
            halfday.GetBrokenRules();
            foreach (BusinessRule rule in halfday.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
        }

        protected override void CheckForValidationsWhileUpdating(WeeklyHalfDay entity)
        {
            throw new NotImplementedException();
        }

        public override WeeklyHalfDayDto EntityToEntityDto(WeeklyHalfDay entity)
        {
            WeeklyHalfDayDto halfdaydto = Mapper.Map<WeeklyHalfDay, WeeklyHalfDayDto>(entity);
            if (entity != null)
            {
                halfdaydto.WeeklyHalfDayOfBranch = Mapper.Map<BankBranch, BankBranchDto>(entity.WeeklyHalfDayOfBranch);
            }
            return halfdaydto;
        }

        public override WeeklyHalfDay EntityDtoToEntity(WeeklyHalfDayDto entityDto)
        {
            WeeklyHalfDay halfday = Mapper.Map<WeeklyHalfDayDto, WeeklyHalfDay>(entityDto);
            if (entityDto != null)
            {
                if (entityDto.WeeklyHalfDayOfBranch != null && entityDto.WeeklyHalfDayOfBranch.BranchId != 0)
                {
                    BankBranchService bankbranchService = new BankBranchService();
                    BankBranchDto bankbranchDto = bankbranchService.GetById(entityDto.WeeklyHalfDayOfBranch.BranchId);
                    halfday.WeeklyHalfDayOfBranch = Mapper.Map<BankBranchDto, BankBranch>(bankbranchDto);
                }
                else
                {
                    halfday.WeeklyHalfDayOfBranch = Mapper.Map<BankBranchDto, BankBranch>(entityDto.WeeklyHalfDayOfBranch);
                }
            }
            return halfday;
        }
        protected override string GetEntityInstanceName(WeeklyHalfDay entity)
        {
            //return entity.Name;
            return string.Empty;
        }
        #endregion 
    }
}

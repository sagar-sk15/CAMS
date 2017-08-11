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
    public class WeeklyOffDaysService : ServiceBase<WeeklyOffDays, WeeklyOffDaysDto>, IWeeklyOffDaysService
    {
        #region Constructor
        public WeeklyOffDaysService()
        {
            AllowSaveWithWarnings = true;
            base.IsValidForBasicMandatoryFields = true;
        }
        #endregion

        #region Override the base abstract methods
        protected override void CheckForValidations(WeeklyOffDays offday)
        {
            offday.GetBrokenRules();
            foreach (BusinessRule rule in offday.GetBrokenRules())
                Container.RequestContext.Notifier.AddWarning(BusinessWarningEnum.Validation, rule.Rule);
        }

        protected override void CheckForValidationsWhileUpdating(WeeklyOffDays entity)
        {
            throw new NotImplementedException();
        }

        public override WeeklyOffDaysDto EntityToEntityDto(WeeklyOffDays entity)
        {
            WeeklyOffDaysDto offdaydto = Mapper.Map<WeeklyOffDays, WeeklyOffDaysDto>(entity);
            if (entity != null)
            {
                offdaydto.WeeklyOffDayOfBranch = Mapper.Map<BankBranch, BankBranchDto>(entity.WeeklyOffDayOfBranch);
            }
            return offdaydto;
        }

        public override WeeklyOffDays EntityDtoToEntity(WeeklyOffDaysDto entityDto)
        {
            WeeklyOffDays offday = Mapper.Map<WeeklyOffDaysDto, WeeklyOffDays>(entityDto);
            if (entityDto != null)
            {
                if (entityDto.WeeklyOffDayOfBranch != null && entityDto.WeeklyOffDayOfBranch.BranchId != 0)
                {
                    BankBranchService bankbranchService = new BankBranchService();
                    BankBranchDto bankbranchDto = bankbranchService.GetById(entityDto.WeeklyOffDayOfBranch.BranchId);
                    offday.WeeklyOffDayOfBranch = Mapper.Map<BankBranchDto, BankBranch>(bankbranchDto);
                }
                else
                {
                    offday.WeeklyOffDayOfBranch = Mapper.Map<BankBranchDto, BankBranch>(entityDto.WeeklyOffDayOfBranch);
                }
            }
            return offday;
        }
        protected override string GetEntityInstanceName(WeeklyOffDays entity)
        {
            //return entity.Name;
            return string.Empty;
        }
        #endregion 
    }
}
